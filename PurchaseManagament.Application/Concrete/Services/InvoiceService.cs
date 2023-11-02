using AutoMapper;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Invoices;
using PurchaseManagament.Application.Concrete.Models.RequestModels.MeasuringUnits;
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
        public async Task<Result<long>> CreateInvoice(CreateInvoiceRM create)
        {
            var result = new Result<long>();
            var mappedEntity = _mapper.Map<Invoice>(create);
            _unitWork.GetRepository<Invoice>().Add(mappedEntity);
            await _unitWork.CommitAsync();
            result.Data = mappedEntity.Id;
            return result;
        }

        public async Task<Result<bool>> DeleteInvoice(long id)
        {
            var result = new Result<bool>();
            var entity = await _unitWork.GetRepository<Invoice>().GetById(id);
            if (entity is null)
            {
                throw new Exception("Böyle id ye sahip stok ürünü bulunamamıştır.");
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
                throw new Exception("Böyle id ye sahip stok ürünü bulunamamıştır.");
            }
            _unitWork.GetRepository<Invoice>().Delete(await entity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        public async Task<Result<HashSet<InvoiceDto>>> GetAllInvoice()
        {
            var result = new Result<HashSet<InvoiceDto>>();
            var entities = _unitWork.GetRepository<Invoice>().GetAllAsync();
            var mappedEntities = _mapper.Map<HashSet<InvoiceDto>>(await entities);
            result.Data = mappedEntities;
            return result;
        }

        public async Task<Result<long>> UpdateInvoice(UpdateInvoiceRM updateInvoiceRM)
        {
            var result = new Result<long>();
            var entity = await _unitWork.GetRepository<Invoice>().GetById(updateInvoiceRM.Id);
            if (entity is null)
            {
                throw new Exception("Stok güncellemesi için id eşleşmesi başarısız oldu.");
            }
            _unitWork.GetRepository<Invoice>().Update(entity);
            await _unitWork.CommitAsync();
            result.Data = entity.Id;
            return result;
        }
    }
}
