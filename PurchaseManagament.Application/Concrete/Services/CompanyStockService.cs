using AutoMapper;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Attributes;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Companies;
using PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyDepartments;
using PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyStocks;
using PurchaseManagament.Application.Concrete.Validators.CompanyStock;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Persistence.Abstract.UnitWork;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PurchaseManagament.Application.Concrete.Services
{
    public class CompanyStockService : ICompanyStockService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;
        private readonly IStockOperationsService _stockOperationsService;

        public CompanyStockService(IMapper mapper, IUnitWork unitWork, IStockOperationsService stockOperationsService)
        {
            _mapper = mapper;
            _unitWork = unitWork;
            _stockOperationsService = stockOperationsService;
        }

        //[Validator(typeof(CreateCompanyStockValidator))]
        public async Task<Result<long>> CreateCompanyStock(CreateCompanyStockRM createCompanyStockRM)
        {
            var result = new Result<long>();
            var mappedEntity = _mapper.Map<CompanyStock>(createCompanyStockRM);
            _unitWork.GetRepository<CompanyStock>().Add(mappedEntity);
            await _unitWork.CommitAsync();
            result.Data = mappedEntity.Id;
            return result;

        }

        public async Task<Result<bool>> DeleteCompanyStock(long id)
        {
            var result = new Result<bool>();
            var entity = await _unitWork.GetRepository<CompanyStock>().GetById(id);
            if (entity is null)
            {
                throw new Exception("Böyle id ye sahip stok ürünü bulunamamıştır.");
            }
            entity.IsDeleted = true;
            _unitWork.GetRepository<CompanyStock>().Update(entity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        public async Task<Result<bool>> DeleteCompanyStockPermanent(long id)
        {
            var result = new Result<bool>();
            var entity = _unitWork.GetRepository<CompanyStock>().GetById(id);
            if (entity is null)
            {
                throw new Exception("Böyle id ye sahip stok ürünü bulunamamıştır.");
            }
            _unitWork.GetRepository<CompanyStock>().Delete(await entity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        public async Task<Result<HashSet<CompanyStocksDto>>> GetAllCompanyStock()
        {
            var result = new Result<HashSet<CompanyStocksDto>>();
            var entities = _unitWork.GetRepository<CompanyStock>().GetAllAsync();
            var mappedEntities = _mapper.Map<HashSet<CompanyStocksDto>>(await entities);
            result.Data = mappedEntities;
            return result;

        }

        public async Task<Result<HashSet<CompanyStocksDto>>> GetAllCompanyStockByCompanyId(Int64 id)
        {
            var result = new Result<HashSet<CompanyStocksDto>>();
            var entities = _unitWork.GetRepository<CompanyStock>().GetByFilterAsync(q => q.CompanyId == id, "Product");
            var mappedEntities = _mapper.Map<HashSet<CompanyStocksDto>>(await entities);
            result.Data = mappedEntities;
            return result;

        }

        //[Validator(typeof(UpdateCompanyStockValidator))]
        public async Task<Result<long>> UpdateCompanyStock(UpdateCompanyStockRM updateCompanyStockRM)
        {
            var result = new Result<long>();
            var entity = await _unitWork.GetRepository<CompanyStock>().GetById(updateCompanyStockRM.Id);
            if (entity is null)
            {
                throw new Exception("Stok güncellemesi için id eşleşmesi başarısız oldu.");
            }
            var mappedEntity = _mapper.Map(updateCompanyStockRM, entity);
            _unitWork.GetRepository<CompanyStock>().Update(mappedEntity);
            await _unitWork.CommitAsync();
            result.Data = entity.Id;
            return result;
        }


        // Adet güncellenmesi
        //[Validator(typeof(UpdateCompanyStockQuantityValidator))]
        public async Task<Result<long>> UpdateCompanyStockQuantity(UpdateCompanyQuantityRM updateCompanyQuantityRM)
        {
            var result = new Result<long>();
            var entity = await _unitWork.GetRepository<CompanyStock>().GetById(updateCompanyQuantityRM.Id);
            if (entity is null)
            {
                throw new Exception("Adet güncellemesi için id eşleşmesi başarısız oldu.");
            }
            if (updateCompanyQuantityRM.ToplaCıkar == true && updateCompanyQuantityRM.ToplaCıkar is not null)
            {
                entity.Quantity = updateCompanyQuantityRM.Quantity + entity.Quantity;
                _unitWork.GetRepository<CompanyStock>().Update(entity);
            }
            else if (updateCompanyQuantityRM.ToplaCıkar == false && updateCompanyQuantityRM.ToplaCıkar is not null)
            {
                entity.Quantity = entity.Quantity  - updateCompanyQuantityRM.Quantity;
                await _stockOperationsService.CreateStockOperations(updateCompanyQuantityRM);
                _unitWork.GetRepository<CompanyStock>().Update(entity);
            }
            else
            {
                throw new Exception("Adet güncellemesi için Islem Secilmedi");
            }

            await _unitWork.CommitAsync();
            result.Data = entity.Id;
            return result;

        }
    }
}
