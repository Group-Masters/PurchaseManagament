using AutoMapper;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Models.RequestModels.EmployeeRoles;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Application.Exceptions;
using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Persistence.Abstract.UnitWork;

namespace PurchaseManagament.Application.Concrete.Services
{
    public class EmployeeRoleService : IEmployeeRoleService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;

        public EmployeeRoleService(IMapper mapper, IUnitWork unitWork)
        {
            _mapper = mapper;
            _unitWork = unitWork;
        }

        //[Validator(typeof(CreateEmployeeRoleValidator))]
        public async Task<Result<bool>> CreateEmployeeRole(CreateEmployeeRoleRM createEmployeeRoleRM)
        {
            var result = new Result<bool>();
            var mappedEntity = _mapper.Map<EmployeeRole>(createEmployeeRoleRM);
            var existsEntity = await _unitWork.GetRepository<EmployeeRole>().AnyAsync(z => z.EmployeeId == mappedEntity.EmployeeId && z.RoleId == mappedEntity.RoleId);
            if (existsEntity)
            {
                throw new AlreadyExistsException("Bu Çalışan/Rol kaydı zaten bulunmakta.");
            }

            _unitWork.GetRepository<EmployeeRole>().Add(mappedEntity);
            var resultBool = await _unitWork.CommitAsync();
            result.Data = resultBool;
            return result;
        }

        //[Validator(typeof(UpdateEmployeeValidator))]
        public async Task<Result<bool>> UpdateEmployeeRole(UpdateEmployeeRoleRM updateEmployeeRoleRM)
        {
            var result = new Result<bool>();
            var entityControl = await _unitWork.GetRepository<EmployeeRole>().AnyAsync(z => z.Id == updateEmployeeRoleRM.Id);
            if (!entityControl)
            {
                throw new NotFoundException("Güncellenmek istenen Çalışan/Rol kaydı bulunamadı.");
            }

            var existEntity = await _unitWork.GetRepository<EmployeeRole>().GetById(updateEmployeeRoleRM.Id);
            existEntity = _mapper.Map(updateEmployeeRoleRM, existEntity);
            _unitWork.GetRepository<EmployeeRole>().Update(existEntity);

            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        public async Task<Result<bool>> DeleteEmployeeRolePermanent(GetByIdVM Id)
        {
            var result = new Result<bool>();
            var existEntity = await _unitWork.GetRepository<EmployeeRole>().AnyAsync(x => x.Id == Id.Id);
            if (!existEntity)
            {
                throw new NotFoundException("Silinmek istenen Çalışan/Rol kaydı bulunamadı.");
            }
            var entity = await _unitWork.GetRepository<EmployeeRole>().GetById(Id.Id);
            _unitWork.GetRepository<EmployeeRole>().Delete(entity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        public async Task<Result<bool>> DeleteEmployeeRole(GetByIdVM Id)
        {
            var result = new Result<bool>();
            var existEntity = await _unitWork.GetRepository<EmployeeRole>().AnyAsync(x => x.Id == Id.Id);
            if (!existEntity)
            {
                throw new NotFoundException("Silinmek istenen Çalışan/Rol kaydı bulunamadı.");
            }
            var entity = await _unitWork.GetRepository<EmployeeRole>().GetById(Id.Id);
            entity.IsDeleted = true;
            _unitWork.GetRepository<EmployeeRole>().Update(entity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        //[Validator(typeof(GetByIdEmployeeValidator))]
        public async Task<Result<HashSet<EmployeeRoleDto>>> GetByEmployeeId(GetByEmployeeIdRM getByEmployeeIdRM)
        {
            var result = new Result<HashSet<EmployeeRoleDto>>();
            var existEntity = await _unitWork.GetRepository<EmployeeRole>().AnyAsync(x => x.EmployeeId == getByEmployeeIdRM.EmployeeId);
            if (!existEntity)
            {
                throw new NotFoundException("İstenen Çalışana ait Çalışan/Rol kaydı bulunamadı.");
            }

            var entities = await _unitWork.GetRepository<EmployeeRole>().GetByFilterAsync(x => x.EmployeeId == getByEmployeeIdRM.EmployeeId);
            var mappedEntity = _mapper.Map<HashSet<EmployeeRoleDto>>(entities);
            result.Data = mappedEntity;
            return result;
        }

        //[Validator(typeof(GetByIdEmployeeValidator))]
        public async Task<Result<HashSet<EmployeeRoleDetailDto>>> GetDetailByEmployeeId(GetByEmployeeIdRM getByEmployeeIdRM)
        {
            var result = new Result<HashSet<EmployeeRoleDetailDto>>();
            var existEntity = await _unitWork.GetRepository<EmployeeRole>().AnyAsync(x => x.EmployeeId == getByEmployeeIdRM.EmployeeId);
            if (!existEntity)
            {
                throw new NotFoundException("İstenen Çalışana ait Çalışan/Rol kaydı bulunamadı.");
            }

            var entities = await _unitWork.GetRepository<EmployeeRole>().GetByFilterAsync(x => x.EmployeeId == getByEmployeeIdRM.EmployeeId, "Employee.EmployeeDetail", "Role");
            var mappedEntity = _mapper.Map<HashSet<EmployeeRoleDetailDto>>(entities);
            result.Data = mappedEntity;
            return result;
        }

        //[Validator(typeof(GetByRoleIdValidator))]
        public async Task<Result<HashSet<EmployeeRoleDto>>> GetByRoleId(GetByRoleIdRM getByRoleIdRM)
        {
            var result = new Result<HashSet<EmployeeRoleDto>>();
            var existEntity = await _unitWork.GetRepository<EmployeeRole>().AnyAsync(x => x.RoleId == getByRoleIdRM.RoleId);
            if (!existEntity)
            {
                throw new NotFoundException("İstenen Role ait herhangi bir Çalışan/Rol kaydı bulunamadı.");
            }

            var entities = await _unitWork.GetRepository<EmployeeRole>().GetByFilterAsync(x => x.RoleId == getByRoleIdRM.RoleId);
            var mappedEntity = _mapper.Map<HashSet<EmployeeRoleDto>>(entities);
            result.Data = mappedEntity;
            return result;
        }

        //[Validator(typeof(GetEmployeeRoleByIdValidator))]
        public async Task<Result<EmployeeRoleDto>> GetEmployeeRoleById(GetEmployeeRoleByIdRM getEmployeeRoleByIdRM)
        {
            var result = new Result<EmployeeRoleDto>();
            var entityControl = await _unitWork.GetRepository<EmployeeRole>().AnyAsync(x => x.Id == getEmployeeRoleByIdRM.Id);
            if (!entityControl)
            {
                throw new NotFoundException("İstenen Çalışan/Rol kaydı bulunamadı.");
            }

            var existEntity = await _unitWork.GetRepository<EmployeeRole>().GetById(getEmployeeRoleByIdRM.Id);
            var mappedEntity = _mapper.Map<EmployeeRoleDto>(existEntity);
            result.Data = mappedEntity;
            return result;
        }

        public async Task<Result<HashSet<EmployeeRoleDto>>> GetAllEmployeeRole()
        {
            var result = new Result<HashSet<EmployeeRoleDto>>();
            var entities = await _unitWork.GetRepository<EmployeeRole>().GetAllAsync();
            var mappedEntity = _mapper.Map<HashSet<EmployeeRoleDto>>(entities);
            result.Data = mappedEntity;
            return result;
        }

        //[Validator(typeof(GetEmployeeRoleByIdValidator))]
        public async Task<Result<EmployeeRoleDetailDto>> GetEmployeeRoleDetailById(GetEmployeeRoleByIdRM getEmployeeRoleByIdRM)
        {
            var result = new Result <EmployeeRoleDetailDto>();
            var entityControl = await _unitWork.GetRepository<EmployeeRole>().AnyAsync(x => x.Id == getEmployeeRoleByIdRM.Id);
            if(!entityControl)
            {
                throw new NotFoundException("Detaylı çıktısı istenen Çalışan/Rol kaydı bulunamadı.");
            }

            var existEntity = await _unitWork.GetRepository<EmployeeRole>().GetSingleByFilterAsync(x => x.Id == getEmployeeRoleByIdRM.Id, "Employee.EmployeeDetail", "Role");
            var mappedEntity = _mapper.Map<EmployeeRoleDetailDto>(existEntity);
            
            result.Data = mappedEntity;
            return result;
        }

        //[Validator(typeof(GetEmployeeRoleByIdValidator))]
        public async Task<Result<HashSet<EmployeeRoleDetailDto>>> GetEmployeeRolesByCompanyId(GetEmployeeRoleByIdRM getEmployeeRoleByIdRM)
        {
            var result = new Result<HashSet<EmployeeRoleDetailDto>>();
            var entity = await _unitWork.GetRepository<EmployeeRole>().GetByFilterAsync(x => x.Employee.CompanyDepartment.CompanyId == getEmployeeRoleByIdRM.Id, "Employee.EmployeeDetail", "Role");
            var mappedEntity = _mapper.Map<HashSet<EmployeeRoleDetailDto>>(entity);

            result.Data = mappedEntity;
            return result;
        }

        public async Task<Result<HashSet<EmployeeRoleDetailDto>>> GetAllEmployeeRoleDetail()
        {
            var result = new Result<HashSet<EmployeeRoleDetailDto>>();

            var existEntity = await _unitWork.GetRepository<EmployeeRole>().GetAllAsync( "Employee.EmployeeDetail", "Role");
            var mappedEntity = _mapper.Map<HashSet<EmployeeRoleDetailDto>>(existEntity);

            result.Data = mappedEntity;
            return result;
        }
    }
}
