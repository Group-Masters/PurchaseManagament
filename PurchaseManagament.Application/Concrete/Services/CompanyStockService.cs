using AutoMapper;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Attributes;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyStocks;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Validators.CompanyStock;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Application.Exceptions;
using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Persistence.Abstract.UnitWork;

namespace PurchaseManagament.Application.Concrete.Services
{
    public class CompanyStockService : ICompanyStockService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;

        public CompanyStockService(IMapper mapper, IUnitWork unitWork)
        {
            _mapper = mapper;
            _unitWork = unitWork;
        }

        [Validator(typeof(CreateCompanyStockValidator))]
        public async Task<Result<long>> CreateCompanyStock(CreateCompanyStockRM createCompanyStockRM)
        {
            var result = new Result<long>();

            var companyStockExists = await _unitWork.GetRepository<CompanyStock>().AnyAsync(x => x.ProductId == createCompanyStockRM.ProductId);
            if (companyStockExists)
            {
                throw new AlreadyExistsException("Eklenmek istenen ürünün Stok kaydı zaten bulunmakta.");
            }
            var mappedEntity = _mapper.Map<CompanyStock>(createCompanyStockRM);
            _unitWork.GetRepository<CompanyStock>().Add(mappedEntity);
            await _unitWork.CommitAsync();
            result.Data = mappedEntity.Id;
            return result;
        }

        [Validator(typeof(DeleteCompanyStockValidator))]
        public async Task<Result<bool>> DeleteCompanyStock(GetByIdVM id)
        {
            var result = new Result<bool>();
            var entity = await _unitWork.GetRepository<CompanyStock>().GetById(id.Id);
            if (entity is null)
            {
                throw new NotFoundException("Silinmek istenen Stok kaydı bulunamadı.");
            }
            entity.IsDeleted = true;
            _unitWork.GetRepository<CompanyStock>().Update(entity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        [Validator(typeof(DeleteCompanyStockValidator))]
        public async Task<Result<bool>> DeleteCompanyStockPermanent(GetByIdVM id)
        {
            var result = new Result<bool>();
            var entity = _unitWork.GetRepository<CompanyStock>().GetById(id.Id);
            if (entity is null)
            {
                throw new NotFoundException("Silinmek istenen Stok kaydı bulunamadı.");
            }
            _unitWork.GetRepository<CompanyStock>().Delete(await entity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        public async Task<Result<HashSet<CompanyStocksDto>>> GetAllCompanyStock()
        {
            var result = new Result<HashSet<CompanyStocksDto>>();
            var entities = _unitWork.GetRepository<CompanyStock>().GetAllAsync("Product.MeasuringUnit");
            var mappedEntities = _mapper.Map<HashSet<CompanyStocksDto>>(await entities);
            result.Data = mappedEntities;
            return result;
        }

        [Validator(typeof(GetCompanyStokByCompanyIdValidator))]
        public async Task<Result<HashSet<CompanyStocksDto>>> GetAllCompanyStockByCompanyId(GetByIdVM getByIdVM)
        {
            var result = new Result<HashSet<CompanyStocksDto>>();
            var entities = _unitWork.GetRepository<CompanyStock>().GetByFilterAsync(q => q.CompanyId == getByIdVM.Id, "Product.MeasuringUnit");
            var mappedEntities = _mapper.Map<HashSet<CompanyStocksDto>>(await entities);
            result.Data = mappedEntities;
            return result;
        }        
        
        [Validator(typeof(GetCompanyStokByIdValidator))]
        public async Task<Result<CompanyStocksDto>> GetCompanyStockById(GetByIdVM getByIdVM)
        {
            var result = new Result<CompanyStocksDto>();
            var entities = _unitWork.GetRepository<CompanyStock>().GetByFilterAsync(q => q.Id == getByIdVM.Id, "Product.MeasuringUnit");
            var mappedEntities = _mapper.Map<CompanyStocksDto>(await entities);
            result.Data = mappedEntities;
            return result;
        }

        [Validator(typeof(UpdateCompanyStockValidator))]
        public async Task<Result<long>> UpdateCompanyStock(UpdateCompanyStockRM updateCompanyStockRM)
        {
            var result = new Result<long>();
            var entity = await _unitWork.GetRepository<CompanyStock>().GetById(updateCompanyStockRM.Id);
            if (entity is null)
            {
                throw new NotFoundException("Güncellenmek istenen Stok kaydı bulunamadı.");
            }
            var mappedEntity = _mapper.Map(updateCompanyStockRM, entity);
            _unitWork.GetRepository<CompanyStock>().Update(mappedEntity);
            await _unitWork.CommitAsync();
            result.Data = entity.Id;
            return result;
        }

        [Validator(typeof(UpdateCompanyStockQuantityValidator))]
        public async Task<Result<long>> UpdateCompanyStockQuantityAdd(UpdateCompanyQuantityAddRM updateCompanyQuantityRM)
        {
            var result = new Result<long>();
            var entity = await _unitWork.GetRepository<CompanyStock>().GetById(updateCompanyQuantityRM.Id);
            if (entity is null)
            {
                throw new NotFoundException("Güncellenmek istenen Stok kaydı bulunamadı.");
            }
            entity.Quantity += updateCompanyQuantityRM.Quantity;
            _unitWork.GetRepository<CompanyStock>().Update(entity);
            await _unitWork.CommitAsync();
            result.Data = entity.Id;
            return result;
        }

        [Validator(typeof(UpdateCompanyStockQuantityReduceValidator))]
        public async Task<Result<long>> UpdateCompanyStockQuantityReduce(UpdateCompanyQuantityReduceRM updateCompanyQuantityReduceRM)
        {
            var result = new Result<long>();
            var entity = await _unitWork.GetRepository<CompanyStock>().GetById(updateCompanyQuantityReduceRM.Id);
            if (entity is null)
            {
                throw new NotFoundException("Güncellenmek istenen Stok kaydı bulunamadı.");
            }

            if (entity.Quantity < updateCompanyQuantityReduceRM.Quantity)
            {
                throw new Exception("Zimmete aktarılacak ürün miktarı Stoktakinden fazla olamaz.");
            }

            entity.Quantity -= updateCompanyQuantityReduceRM.Quantity;
            _unitWork.GetRepository<CompanyStock>().Update(entity);

            var sOparetionEntity = new StockOperations
            {
                CompanyStockId = entity.Id,
                Quantity = updateCompanyQuantityReduceRM.Quantity,
                ReceivingEmployeeId = updateCompanyQuantityReduceRM.ReceivingEmployeeId
            };

            _mapper.Map<CompanyStock>(entity);
            _unitWork.GetRepository<StockOperations>().Add(sOparetionEntity);
            await _unitWork.CommitAsync();
            result.Data = entity.Id;
            return result;
        }

        [Validator(typeof(ReturnProductToStockValidator))]
        public async Task<Result<long>> ReturnProductToStock(ReturnProductToStockRM returnProductToStockRM)
        {
            var result = new Result<long>();

            var stockOperationExists = await _unitWork.GetRepository<StockOperations>().AnyAsync(x => x.Id == returnProductToStockRM.Id);
            if (!stockOperationExists)
            {
                throw new NotFoundException("İstenen Stok/İşlem kaydı bulunamadı.");
            }

            var companyStockExists = await _unitWork.GetRepository<CompanyStock>().AnyAsync(x => x.Id == returnProductToStockRM.CompanyStockId);
            if (!companyStockExists)
            {
                throw new NotFoundException("İstenen Stok kaydı bulunamadı.");
            }

            var stockOperation = await _unitWork.GetRepository<StockOperations>().GetById(returnProductToStockRM.Id);
            if (stockOperation.Quantity < returnProductToStockRM.Quantity)
            {
                throw new Exception("İade edilecek ürün miktarı, zimmette bulunandan fazla olamaz.");
            }

            var companyStock = await _unitWork.GetRepository<CompanyStock>().GetById(returnProductToStockRM.CompanyStockId);

            stockOperation.Quantity -= returnProductToStockRM.Quantity;
            companyStock.Quantity += returnProductToStockRM.Quantity;

            _unitWork.GetRepository<CompanyStock>().Update(companyStock);
            _unitWork.GetRepository<StockOperations>().Update(stockOperation);

            await _unitWork.CommitAsync();
            result.Data = stockOperation.Id;
            return result;
        }

        // Adet güncellenmesi
        //[Validator(typeof(UpdateCompanyStockQuantityValidator))]

    }
}
