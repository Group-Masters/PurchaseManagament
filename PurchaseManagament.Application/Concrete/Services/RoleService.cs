using AutoMapper;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Attributes;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Roles;
using PurchaseManagament.Application.Concrete.Validators.Role;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Application.Exceptions;
using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Persistence.Abstract.UnitWork;

namespace PurchaseManagament.Application.Concrete.Services
{
    public class RoleService : IRoleService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;

        public RoleService(IMapper mapper, IUnitWork unitWork)
        {
            _mapper = mapper;
            _unitWork = unitWork;
        }

        [Validator(typeof(CreateRoleValidator))]
        public async Task<Result<bool>> CreateRole(CreateRoleRM createRoleRM)
        {
            var result = new Result<bool>();
            var existsEntity = await _unitWork.GetRepository<Role>().AnyAsync(z => z.Name == createRoleRM.Name);
            if (existsEntity)
            {
                throw new AlreadyExistsException("Bu isimde bir Rol kaydı zaten bulunmakta.");
            }

            var mappedEntity = _mapper.Map<Role>(createRoleRM);
            _unitWork.GetRepository<Role>().Add(mappedEntity);
            var resultBool = await _unitWork.CommitAsync();
            result.Data = resultBool;
            return result;
        }

        [Validator(typeof(DeleteRoleValidator))]
        public async Task<Result<bool>> DeleteRolePermanent(GetByIdVM Id)
        {
            var result = new Result<bool>();
            var existEntity = await _unitWork.GetRepository<Role>().AnyAsync(x => x.Id == Id.Id);
            if (!existEntity)
            {
                throw new NotFoundException("Silinmek istenen Rol kaydı bulunamadı.");
            }
            var entity = await _unitWork.GetRepository<Role>().GetById(Id.Id);
            _unitWork.GetRepository<Role>().Delete(entity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        [Validator(typeof(DeleteRoleValidator))]
        public async Task<Result<bool>> DeleteRole(GetByIdVM Id)
        {
            var result = new Result<bool>();
            var existEntity = await _unitWork.GetRepository<Role>().AnyAsync(x => x.Id == Id.Id);
            if (!existEntity)
            {
                throw new NotFoundException("Silinmek istenen Rol kaydı bulunamadı.");
            }
            var entity = await _unitWork.GetRepository<Role>().GetById(Id.Id);
            entity.IsDeleted = true;
            _unitWork.GetRepository<Role>().Update(entity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        public async Task<Result<HashSet<RoleDto>>> GetAllRole()
        {
            var result = new Result<HashSet<RoleDto>>();
            var entities = await _unitWork.GetRepository<Role>().GetAllAsync();
            var mappedEntity = _mapper.Map<HashSet<RoleDto>>(entities);
            result.Data = mappedEntity;
            return result;
        }

        [Validator(typeof(GetRoleByIdNameValidator))]
        public async Task<Result<RoleDto>> GetRoleByName(GetRoleByNameRM getRoleByNameRM)
        {
            var result = new Result<RoleDto>();
            var existEntity = await _unitWork.GetRepository<Role>().AnyAsync(x => x.Name.ToUpper().Trim() == getRoleByNameRM.Name.ToUpper().Trim());
            if (!existEntity)
            {
                throw new NotFoundException("İstenen Rol kaydı bulunamadı.");
            }
            var entity = await _unitWork.GetRepository<Role>().GetByFilterAsync(x => x.Name.ToUpper().Trim() == getRoleByNameRM.Name.ToUpper().Trim());
            var mappedEntity = _mapper.Map<RoleDto>(entity);
            result.Data = mappedEntity;
            return result;
        }

        [Validator(typeof(UpdateRoleValidator))]
        public async Task<Result<bool>> UpdateRole(UpdateRoleRM updateRoleRM)
        {
            var result = new Result<bool>();
            var entityControl = await _unitWork.GetRepository<Role>().AnyAsync(z => z.Id == updateRoleRM.Id);
            if (!entityControl)
            {
                throw new NotFoundException("Güncellenmek istenen Rol kaydı bulunamadı.");
            }

            var existEntity = await _unitWork.GetRepository<Role>().GetById(updateRoleRM.Id);
            existEntity = _mapper.Map(updateRoleRM, existEntity);
            _unitWork.GetRepository<Role>().Update(existEntity);

            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        [Validator(typeof(GetRoleByIdValidator))]
        public async Task<Result<RoleDto>> GetRoleById(GetRoleByIdRM getRoleByIdRM)
        {
            var result = new Result<RoleDto>();
            var entityControl = await _unitWork.GetRepository<Role>().AnyAsync(x => x.Id == getRoleByIdRM.Id);
            if (!entityControl)
            {
                throw new NotFoundException("İstenen Rol kaydı bulunamadı.");
            }

            var existEntity = await _unitWork.GetRepository<Role>().GetById(getRoleByIdRM.Id);
            var mappedEntity = _mapper.Map<RoleDto>(existEntity);
            result.Data = mappedEntity;
            return result;
        }
    }
}
