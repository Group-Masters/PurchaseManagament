using AutoMapper;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Attributes;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Invoices;
using PurchaseManagament.Application.Concrete.Validators.Employees;
using PurchaseManagament.Application.Concrete.Validators.Invoices;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Persistence.Abstract.UnitWork;

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
                ("Offer.Request.RequestEmployee.CompanyDepartment.Company", "Offer.Supplier", "Offer.Request", "Offer.Request.Product", "Offer");
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
                (x => x.Id == getInvoiceById.Id, "Offer.Request.RequestEmployee.CompanyDepartment.Company", "Offer.Supplier", "Offer.Request", "Offer.Request.Product", "Offer");
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
                (x => x.Offer.Request.RequestEmployee.CompanyDepartment.CompanyId == getInvoiceById.Id, "Offer.Request.RequestEmployee.CompanyDepartment.Company", "Offer.Supplier", "Offer.Request", "Offer.Request.Product", "Offer");
            var mappedEntity = _mapper.Map<HashSet<InvoiceDto>>(entity);

            result.Data = mappedEntity;
            return result;
        }
    }
}
