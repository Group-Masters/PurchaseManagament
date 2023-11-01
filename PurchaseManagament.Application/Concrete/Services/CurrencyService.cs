﻿using AutoMapper;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Currency;
using PurchaseManagament.Application.Concrete.Models.RequestModels.MeasuringUnits;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Persistence.Abstract.UnitWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Application.Concrete.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;
        public CurrencyService(IMapper mapper, IUnitWork unitWork)
        {
            _mapper = mapper;
            _unitWork = unitWork;
        }


        public async Task<Result<long>> CreateCurrency(CreateCurrencyRM createCurrencyRM)
        {
            var result = new Result<long>();
            var mappedEntity = _mapper.Map<Currency>(createCurrencyRM);
            _unitWork.GetRepository<Currency>().Add(mappedEntity);
            await _unitWork.CommitAsync();
            result.Data = mappedEntity.Id;
            return result;
        }

        public async Task<Result<bool>> DeleteCurrency(Int64 id)
        {
            var result = new Result<bool>();
            var entity = await _unitWork.GetRepository<Currency>().GetById(id);
            if (entity is null)
            {
                throw new Exception("Böyle id ye sahip para birimi bulunamamıştır.");
            }
            entity.IsDeleted = true;
            _unitWork.GetRepository<Currency>().Update(entity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        public async Task<Result<bool>> DeleteCurrencyPermanent(long id)
        {
            var result = new Result<bool>();
            var entity = _unitWork.GetRepository<Currency>().GetById(id);
            if (entity is null)
            {
                throw new Exception("Böyle id ye sahip para birimi bulunamamıştır.");
            }
            _unitWork.GetRepository<Currency>().Delete(await entity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        public async Task<Result<HashSet<CurrencyDTO>>> GetAllCurrency()
        {
            var result = new Result<HashSet<CurrencyDTO>>();
            var entities = _unitWork.GetRepository<Currency>().GetAllAsync();
            var mappedEntities = _mapper.Map<HashSet<CurrencyDTO>>(await entities);
            result.Data = mappedEntities;
            return result;
        }

        public async Task<Result<long>> UpdateCurrency(UpdateCurrencyRM updateCurrencyRM)
        {
            var result = new Result<long>();
            var entity = await _unitWork.GetRepository<Currency>().GetById(updateCurrencyRM.Id);
            if (entity is null)
            {
                throw new Exception("Stok güncellemesi için id eşleşmesi başarısız oldu.");
            }
            var mappedEntity = _mapper.Map(updateCurrencyRM, entity);
            _unitWork.GetRepository<Currency>().Update(mappedEntity);
            await _unitWork.CommitAsync();
            result.Data = entity.Id;
            return result;
        }
    }
}