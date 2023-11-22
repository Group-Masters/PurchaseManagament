using AutoMapper;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Materials;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Persistence.Abstract.UnitWork;

namespace PurchaseManagament.Application.Concrete.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;

        public MaterialService(IMapper mapper, IUnitWork unitWork)
        {
            _mapper = mapper;
            _unitWork = unitWork;
        }

        public async Task<Result<long>> CreateMaterial(CreateMaterialRM? createMaterialRM)
        {
            var result = new Result<long>();

            var mappedEntity = _mapper.Map<Material>(createMaterialRM);
            _unitWork.GetRepository<Material>().Add(mappedEntity);

            await _unitWork.CommitAsync();
            result.Data = mappedEntity.Id;
            return result;
        }

        public async Task<Result<long>> UpdateMaterial(UpdateMaterialRM updateMaterialRM)
        {
            var result = new Result<long>();
            
            var entity = await _unitWork.GetRepository<Material>().GetById(updateMaterialRM);
            var mappedEntity = _mapper.Map(updateMaterialRM, entity);
            _unitWork.GetRepository<Material>().Update(mappedEntity);

            await _unitWork.CommitAsync();
            result.Data = mappedEntity.Id;
            return result;
        }

        public async Task<Result<bool>> DeleteMaterial(GetByIdVM id)
        {
            var result = new Result<bool>();

            var entity = await _unitWork.GetRepository<Material>().GetById(id.Id);
            entity.IsDeleted = true;
            _unitWork.GetRepository<Material>().Update(entity);
            
            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        public async Task<Result<bool>> DeleteMaterialPermanent(GetByIdVM id)
        {
            var result = new Result<bool>();

            var entity = _unitWork.GetRepository<Material>().GetById(id.Id);
            _unitWork.GetRepository<Material>().Delete(await entity);
            
            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        public async Task<Result<MaterialDto>> GetMaterialById(GetByIdVM getMaterialById)
        {
            var result = new Result<MaterialDto>();

            var entity = await _unitWork.GetRepository<Material>().GetSingleByFilterAsync(x => x.Id == getMaterialById.Id, "Product.MeasuringUnit");
            var mappedEntity = _mapper.Map<MaterialDto>(entity);

            result.Data = mappedEntity;
            return result;
        }

        public async Task<Result<HashSet<MaterialDto>>> GetMaterialByEmployeeId(GetByIdVM getMaterialByEmployeeIdRM)
        {
            var result = new Result<HashSet<MaterialDto>>();

            var entity = await _unitWork.GetRepository<Material>().GetByFilterAsync(x => x.Request.RequestEmployeeId == getMaterialByEmployeeIdRM.Id, "Product.MeasuringUnit");
            var mappedEntity = _mapper.Map<HashSet<MaterialDto>>(entity);

            result.Data = mappedEntity;
            return result;
        }

        public async Task<Result<HashSet<MaterialDto>>> GetMaterialByRequestId(GetByIdVM getMaterialByRequestIdRM)
        {
            var result = new Result<HashSet<MaterialDto>>();

            var entity = await _unitWork.GetRepository<Material>().GetByFilterAsync(x => x.RequestId == getMaterialByRequestIdRM.Id, "Product.MeasuringUnit");
            var mappedEntity = _mapper.Map<HashSet<MaterialDto>>(entity);

            result.Data = mappedEntity;
            return result;
        }

        public async Task<Result<HashSet<MaterialDto>>> GetAllMaterial()
        {
            var result = new Result<HashSet<MaterialDto>>();

            var entity = await _unitWork.GetRepository<Material>().GetAllAsync("Product.MeasuringUnit");
            var mappedEntity = _mapper.Map<HashSet<MaterialDto>>(entity);

            result.Data = mappedEntity;
            return result;
        }
    }
}
