﻿using AutoMapper;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Companies;
using PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyDepartments;
using PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyStocks;
using PurchaseManagament.Application.Concrete.Wrapper;
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
            var entity = _unitWork.GetRepository<CompanyStock>().GetById(id);
            if (entity is null)
            {
                throw new Exception("Böyle id ye sahip stok ürünü bulunamamıştır.");
            }
            _unitWork.GetRepository<CompanyStock>().Delete(entity);
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
            _unitWork.GetRepository<CompanyStock>().Delete(entity);
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

        public async Task<Result<long>> UpdateCompanyStock(UpdateCompanyStockRM updateCompanyStockRM)
        {
            var result = new Result<long>();
            var entity = await _unitWork.GetRepository<CompanyStock>().GetById(updateCompanyStockRM.Id);
            if (entity is null)
            {
                throw new Exception("Stok güncellemesi için id eşleşmesi başarısız oldu.");
            }
            _unitWork.GetRepository<CompanyStock>().Update(entity);
            await _unitWork.CommitAsync();
            result.Data = entity.Id;
            return result;
        }
    }
}
