using AutoMapper;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Attributes;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Invoices;
using PurchaseManagament.Application.Concrete.Validators.Employees;
using PurchaseManagament.Application.Concrete.Validators.Invoices;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Application.Exceptions;
using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Domain.Enums;
using PurchaseManagament.Persistence.Abstract.UnitWork;
using PurchaseManagament.Utils;

namespace PurchaseManagament.Application.Concrete.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;

        public InvoiceService(IMapper mapper, IUnitWork unitWork)
        {
            _mapper = mapper;
            _unitWork = unitWork;
        }

        //[Validator(typeof(CreateInvoiceValidator))]
        public async Task<Result<long>> CreateInvoice(CreateInvoiceRM create)
        {
            var result = new Result<long>();
            var mappedEntity = _mapper.Map<Invoice>(create);
            var offerEntity = await _unitWork.GetRepository<Offer>().GetSingleByFilterAsync(x=>x.Id==create.OfferId,"Request");
            if (offerEntity is null)
            {
                throw new NotFoundException("Teklif bulunmadı.");
            }
            offerEntity.Status = Status.FaturaEklendi;
            offerEntity.Request.State=Status.FaturaEklendi;
            _unitWork.GetRepository<Offer>().Update(offerEntity);
            _unitWork.GetRepository<Invoice>().Add(mappedEntity);
            await _unitWork.CommitAsync();
            result.Data = mappedEntity.Id;
            return result;
        }

        //[Validator(typeof(UpdateInvoiceValidator))]
        public async Task<Result<long>> UpdateInvoice(UpdateInvoiceRM updateInvoiceRM)
        {
            var result = new Result<long>();
            var entity = await _unitWork.GetRepository<Invoice>().GetById(updateInvoiceRM.Id);
            if (entity is null)
            {
                throw new Exception($"{updateInvoiceRM.Id} ID'li fatura bulunamadı.");
            }
            _mapper.Map(updateInvoiceRM, entity);
            _unitWork.GetRepository<Invoice>().Update(entity);
            await _unitWork.CommitAsync();
            result.Data = entity.Id;
            return result;
        }

        public async Task<Result<bool>> DeleteInvoice(long id)
        {
            var result = new Result<bool>();
            var entity = await _unitWork.GetRepository<Invoice>().GetById(id);
            if (entity is null)
            {
                throw new Exception($"{id} ID'li fatura bulunamadı.");
            }
            entity.IsDeleted = true;
            _unitWork.GetRepository<Invoice>().Update(entity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        public async Task<Result<bool>> DeleteInvoicePermanent(long id)
        {
            var result = new Result<bool>();
            var entity = _unitWork.GetRepository<Invoice>().GetById(id);
            if (entity is null)
            {
                throw new Exception($"{id} ID'li fatura bulunamadı.");
            }
            _unitWork.GetRepository<Invoice>().Delete(await entity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        public async Task<Result<HashSet<InvoiceDto>>> GetAllInvoice()
        {
            var result = new Result<HashSet<InvoiceDto>>();
            var entities = await _unitWork.GetRepository<Invoice>().GetAllAsync
                ("Offer.Request.RequestEmployee.CompanyDepartment.Company", "Offer.Supplier", "Offer.Request.Product.MeasuringUnit", "Offer.Currency");
            var mappedEntity = _mapper.Map<HashSet<InvoiceDto>>(entities);
            result.Data = mappedEntity;
            return result;
        }

        //[Validator(typeof(UpdateInvoiceValidator))]
        public async Task<Result<InvoiceDto>> GetInvoiceById(GetInvoiceByIdRM getInvoiceById)
        {
            var result = new Result<InvoiceDto>();
            var entityControl = await _unitWork.GetRepository<Invoice>().AnyAsync(x => x.Id == getInvoiceById.Id);
            if (!entityControl)
            {
                throw new Exception($"{getInvoiceById.Id} ID'li fatura bulunamadı.");
            }

            var existEntity = await _unitWork.GetRepository<Invoice>().GetSingleByFilterAsync
                (x => x.Id == getInvoiceById.Id, "Offer.Request.RequestEmployee.CompanyDepartment.Company", "Offer.Supplier", "Offer.Request.Product.MeasuringUnit", "Offer.Currency");
            var mappedEntity = _mapper.Map<InvoiceDto>(existEntity);
            result.Data = mappedEntity;
            return result;
        }

        //[Validator(typeof(UpdateInvoiceValidator))]
        public async Task<Result<HashSet<InvoiceDto>>> GetInvoicesByCompanyId(GetInvoiceByIdRM getInvoiceById)
        {
            var result = new Result<HashSet<InvoiceDto>>();
            var entityControl = await _unitWork.GetRepository<Invoice>().AnyAsync(x => x.Offer.Request.RequestEmployee.CompanyDepartment.CompanyId == getInvoiceById.Id);
            if (!entityControl)
            {
                throw new Exception($"{getInvoiceById.Id} ID'li şirkete ait fatura bulunamadı.");
            }
            var entity = await _unitWork.GetRepository<Invoice>().GetByFilterAsync
                (x => x.Offer.Request.RequestEmployee.CompanyDepartment.CompanyId == getInvoiceById.Id, "Offer.Request.RequestEmployee.CompanyDepartment.Company", "Offer.Supplier", "Offer.Request.Product.MeasuringUnit", "Offer.Currency");
            var mappedEntity = _mapper.Map<HashSet<InvoiceDto>>(entity);

            result.Data = mappedEntity;
            return result;
        }

        public async Task<Result<HashSet<InvoiceDto>>> GetPendingInvoicesByCompanyId(GetInvoiceByIdRM getInvoiceById)
        {
            var result = new Result<HashSet<InvoiceDto>>();
            var entityControl = await _unitWork.GetRepository<Invoice>().AnyAsync(x => x.Offer.Request.RequestEmployee.CompanyDepartment.CompanyId == getInvoiceById.Id && x.Status == Status.FaturaEklendi);
            if (!entityControl)
            {
                throw new Exception($"{getInvoiceById.Id} ID'li şirkete ait fatura bulunamadı.");
            }
            var entity = await _unitWork.GetRepository<Invoice>().GetByFilterAsync
                (x => x.Offer.Request.RequestEmployee.CompanyDepartment.CompanyId == getInvoiceById.Id, "Offer.Request.RequestEmployee.CompanyDepartment.Company", "Offer.Supplier", "Offer.Request.Product.MeasuringUnit", "Offer.Currency");
            var mappedEntity = _mapper.Map<HashSet<InvoiceDto>>(entity);

            result.Data = mappedEntity;
            return result;
        }

        public async Task<Result<long>> UpdateInvoiceState(UpdateInvoiceStatusRM update)
        {
            var result = new Result<long>();
            var entityInvoice = await _unitWork.GetRepository<Invoice>().GetSingleByFilterAsync(x=>x.Id==update.Id, "Offer.Request.RequestEmployee.EmployeeDetail", "Offer.Request.Product.MeasuringUnit");
            if (update is null)
            {
                throw new NotFoundException("Fatura bilgisi bulunamadı.");
            }
            var entity = _mapper.Map(update, entityInvoice);
            if (entity.Status == Status.Tamamlandı)
            {
                entity.Offer.Status = Status.Tamamlandı;
                entity.Offer.Request.State = Status.Tamamlandı;
                _unitWork.GetRepository<Invoice>().Update(entity);
                SenderUtils.SendMail(entityInvoice.Offer.Request.RequestEmployee.EmployeeDetail.Email, "TAMAMLANAN TALEP", 
                    $"{entityInvoice.Offer.RequestId} talep numaralı talebiniz tamamlanmıştır. Stoktan temin edebilirsiniz . Talep içeriğiniz : {entityInvoice.Offer.Request.Quantity}- Adet " +
                    $"{entityInvoice.Offer.Request.Product.Name}-{entityInvoice.Offer.Request.Product.MeasuringUnit.Name} ");

            }
            await _unitWork.CommitAsync();
            result.Data = entity.Id;
            return result;
        }
    }
}
