﻿using AutoMapper;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.MeasuringUnits;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Persistence.Abstract.UnitWork;

namespace PurchaseManagament.Application.Concrete.Services
{
    public class MeasuringUnitService : IMeasuringUnitService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;

        public MeasuringUnitService(IMapper mapper, IUnitWork unitWork)
        {
            _mapper = mapper;
            _unitWork = unitWork;
        }

        public async Task<Result<long>> CreateMeasuringUnit(CreateMeasuringUnitRM createMeasuringUnitRM)
        {
            var result = new Result<long>();
            var mappedEntity = _mapper.Map<MeasuringUnit>(createMeasuringUnitRM);
            _unitWork.GetRepository<MeasuringUnit>().Add(mappedEntity);
            await _unitWork.CommitAsync();
            result.Data = mappedEntity.Id;
            return result;
        }

        public async Task<Result<bool>> DeleteMeasuringUnit(Int64 id)
        {
            var result = new Result<bool>();
            var entity = await _unitWork.GetRepository<MeasuringUnit>().GetById(id);
            if (entity is null)
            {
                throw new Exception("Böyle id ye sahip stok ürünü bulunamamıştır.");
            }
            entity.IsDeleted = true;
            _unitWork.GetRepository<MeasuringUnit>().Update(entity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        public async Task<Result<bool>> DeleteMeasuringUnitPermanent(long id)
        {
            var result = new Result<bool>();
            var entity =  _unitWork.GetRepository<MeasuringUnit>().GetById(id);
            if (entity is null)
            {
                throw new Exception("Böyle id ye sahip stok ürünü bulunamamıştır.");
            }
            _unitWork.GetRepository<MeasuringUnit>().Delete(await entity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        public async Task<Result<HashSet<MeasuringUnitDto>>> GetAllMeasuringUnit()
        {
            var result = new Result<HashSet<MeasuringUnitDto>>();
            var entities = _unitWork.GetRepository<MeasuringUnit>().GetAllAsync();
            var mappedEntities = _mapper.Map<HashSet<MeasuringUnitDto>>(await entities);
            result.Data = mappedEntities;
            return result;
        }

        public async Task<Result<long>> UpdateMeasuringUnit(UpdateMeasuringUnitRM updateMeasuringUnitRM)
        {
            var result = new Result<long>();
            var entity = await _unitWork.GetRepository<MeasuringUnit>().GetById(updateMeasuringUnitRM.Id);
            if (entity is null)
            {
                throw new Exception("Stok güncellemesi için id eşleşmesi başarısız oldu.");
            }
            _unitWork.GetRepository<MeasuringUnit>().Update(entity);
            await _unitWork.CommitAsync();
            result.Data = entity.Id;
            return result;
        }
    }
}
