﻿using AutoMapper;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyStocks;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
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
            var entities = _unitWork.GetRepository<CompanyStock>().GetAllAsync("Product.MeasuringUnit");
            var mappedEntities = _mapper.Map<HashSet<CompanyStocksDto>>(await entities);
            result.Data = mappedEntities;
            return result;

        }

        public async Task<Result<HashSet<CompanyStocksDto>>> GetAllCompanyStockByCompanyId(GetByIdVM getByIdVM)
        {
            var result = new Result<HashSet<CompanyStocksDto>>();
            var entities = _unitWork.GetRepository<CompanyStock>().GetByFilterAsync(q => q.CompanyId == getByIdVM.Id, "Product.MeasuringUnit");
            var mappedEntities = _mapper.Map<HashSet<CompanyStocksDto>>(await entities);
            result.Data = mappedEntities;
            return result;
        }        
        
        public async Task<Result<CompanyStocksDto>> GetCompanyStockById(GetByIdVM getByIdVM)
        {
            var result = new Result<CompanyStocksDto>();
            var entities = _unitWork.GetRepository<CompanyStock>().GetByFilterAsync(q => q.Id == getByIdVM.Id, "Product.MeasuringUnit");
            var mappedEntities = _mapper.Map<CompanyStocksDto>(await entities);
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

        public async Task<Result<long>> UpdateCompanyStockQuantityAdd(UpdateCompanyQuantityAddRM updateCompanyQuantityRM)
        {
            var result = new Result<long>();
            var entity = await _unitWork.GetRepository<CompanyStock>().GetById(updateCompanyQuantityRM.Id);
            if (entity is null)
            {
                throw new NotFoundException("Stok BuluNamdı");
            }
            entity.Quantity += updateCompanyQuantityRM.Quantity;
            _unitWork.GetRepository<CompanyStock>().Update(entity);
            await _unitWork.CommitAsync();
            result.Data = entity.Id;
            return result;


        }

        public async Task<Result<long>> UpdateCompanyStockQuantityReduce(UpdateCompanyQuantityReduceRM updateCompanyQuantityReduceRM)
        {
            var result = new Result<long>();
            var entity = await _unitWork.GetRepository<CompanyStock>().GetById(updateCompanyQuantityReduceRM.Id);
            if (entity is null)
            {
                throw new NotFoundException("Stok BuluNamdı");
            }
            entity.Quantity -= updateCompanyQuantityReduceRM.Quantity;
            _unitWork.GetRepository<CompanyStock>().Update(entity);


            var sOparetionEntity = new StockOperations
            {
                CompanyStockId = entity.Id,
                Quantity = updateCompanyQuantityReduceRM.Quantity,
                CompanyDepartmentId = updateCompanyQuantityReduceRM.CompanyDepartmentId

            };
            _mapper.Map<CompanyStock>(entity);
            _unitWork.GetRepository<StockOperations>().Add(sOparetionEntity);
            await _unitWork.CommitAsync();
            result.Data = entity.Id;
            return result;
        }


        // Adet güncellenmesi
        //[Validator(typeof(UpdateCompanyStockQuantityValidator))]


    }
}
