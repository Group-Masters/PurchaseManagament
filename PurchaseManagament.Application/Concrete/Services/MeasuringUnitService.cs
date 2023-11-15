using AutoMapper;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Attributes;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Models.RequestModels.MeasuringUnits;
using PurchaseManagament.Application.Concrete.Validators.MeasuringUnits;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Application.Exceptions;
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

        [Validator(typeof(CreateMeasuringUnit))]
        public async Task<Result<long>> CreateMeasuringUnit(CreateMeasuringUnitRM createMeasuringUnitRM)
        {
            var result = new Result<long>();

            var measuringUnitExists = await _unitWork.GetRepository<MeasuringUnit>().AnyAsync(x => x.Name == createMeasuringUnitRM.Name);
            if (measuringUnitExists)
            {
                throw new AlreadyExistsException("Bu isimde bir Ölçü Birimi kaydı zaten bulunmakta.");
            }
            var mappedEntity = _mapper.Map<MeasuringUnit>(createMeasuringUnitRM);
            _unitWork.GetRepository<MeasuringUnit>().Add(mappedEntity);
            await _unitWork.CommitAsync();
            result.Data = mappedEntity.Id;
            return result;
        }

        [Validator(typeof(GetByIdValidator))]
        public async Task<Result<bool>> DeleteMeasuringUnit(GetByIdVM id)
        {
            var result = new Result<bool>();
            var entity = await _unitWork.GetRepository<MeasuringUnit>().GetById(id.Id);
            if (entity is null)
            {
                throw new NotFoundException("Silinmek istenen Ölçü Birimi kaydı bulunamadı.");
            }
            entity.IsDeleted = true;
            _unitWork.GetRepository<MeasuringUnit>().Update(entity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        [Validator(typeof(GetByIdValidator))]
        public async Task<Result<bool>> DeleteMeasuringUnitPermanent(GetByIdVM id)
        {
            var result = new Result<bool>();
            var entity =  _unitWork.GetRepository<MeasuringUnit>().GetById(id.Id);
            if (entity is null)
            {
                throw new NotFoundException("Silinmek istenen Ölçü Birimi kaydı bulunamadı.");
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

        public async Task<Result<MeasuringUnitDto>> GetMeasuringUnitByProductId(Int64 id)
        {
            var result = new Result<MeasuringUnitDto>();
            var entity = await _unitWork.GetRepository<Product>().GetSingleByFilterAsync(q => q.Id == id);
            var entityTwo = _unitWork.GetRepository<MeasuringUnit>().GetSingleByFilterAsync(q => q.Id == entity.MeasuringUnitId);
            var mappedEntity = _mapper.Map<MeasuringUnitDto>(await entityTwo);
            result.Data = mappedEntity;
            return result;
        }

        [Validator(typeof(UpdateMeasuringUnit))]
        public async Task<Result<long>> UpdateMeasuringUnit(UpdateMeasuringUnitRM updateMeasuringUnitRM)
        {
            var result = new Result<long>();
            var entity = await _unitWork.GetRepository<MeasuringUnit>().GetById(updateMeasuringUnitRM.Id);
            if (entity is null)
            {
                throw new NotFoundException("Güncellenmek istenen Ölçü Birimi kaydı bulunamadı.");
            }
            _unitWork.GetRepository<MeasuringUnit>().Update(entity);
            await _unitWork.CommitAsync();
            result.Data = entity.Id;
            return result;
        }
    }
}
