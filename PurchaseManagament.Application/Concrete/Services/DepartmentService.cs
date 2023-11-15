using AutoMapper;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Attributes;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Departments;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Validators.Departman;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Application.Exceptions;
using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Persistence.Abstract.UnitWork;

namespace PurchaseManagament.Application.Concrete.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitWork _unitWork;
        private readonly IMapper _mapper;

        public DepartmentService(IUnitWork unitWork, IMapper mapper)
        {
            _unitWork = unitWork;
            _mapper = mapper;
        }

        [Validator(typeof(CreateDepartmanValidator))]
        public async Task<Result<bool>> CreateDepartment(CreateDepartmentRM createDepartmentRM)
        {
            var result = new Result<bool>();

            var departmentExists = await _unitWork.GetRepository<Department>().AnyAsync(x => x.Name == createDepartmentRM.Name);
            if (departmentExists)
            {
                throw new AlreadyExistsException("Bu isimde bir Departman kaydı zaten bulunmakta.");
            }

            var mappedEntity = _mapper.Map<Department>(createDepartmentRM);
            if (mappedEntity != null) 
            {
                _unitWork.GetRepository<Department>().Add(mappedEntity);
                result.Success = true;
                result.Data = await _unitWork.CommitAsync();
            }
            else { result.Success = false; }
            return result;
        }
        [Validator(typeof(DeleteDepartmanValidator))]
        public async Task<Result<bool>> DeleteDepartment(GetByIdVM id)
        {
            var result = new Result<bool>();
            var existEntity = await _unitWork.GetRepository<Department>().AnyAsync(x => x.Id == id.Id);
            if (!existEntity)
            {
                throw new NotFoundException("Silinmek istenen Departman kaydı bulunamadı.");
            }
            var entity = await _unitWork.GetRepository<Department>().GetById(id.Id);
            entity.IsDeleted = true;
            _unitWork.GetRepository<Department>().Update(entity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }
        [Validator(typeof(DeleteDepartmanValidator))]
        public async Task<Result<bool>> DeleteDepartmentPermanent(GetByIdVM id)
        {
            var result = new Result<bool>();
            var existEntity = await _unitWork.GetRepository<Department>().AnyAsync(x => x.Id == id.Id);
            if (!existEntity)
            {
                throw new NotFoundException("Silinmek istenen Departman kaydı bulunamadı.");
            }
            var entity = await _unitWork.GetRepository<Department>().GetById(id.Id);
            _unitWork.GetRepository<Department>().Delete(entity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }
        [Validator(typeof(GetByIdDepartmanValidator))]
        public async Task<Result<DepartmentDto>> GetDepartmentById(GetByIdDepartmentRM getByIdDepartmentRM)
        {
            var result = new Result<DepartmentDto>();
            var entityControl = await _unitWork.GetRepository<Department>().AnyAsync(x => x.Id == getByIdDepartmentRM.Id);
            if (!entityControl)
            {
                throw new NotFoundException("İstenen Departman kaydı bulunamadı.");
            }

            var existEntity = await _unitWork.GetRepository<Department>().GetById(getByIdDepartmentRM.Id);
            var mappedEntity = _mapper.Map<DepartmentDto>(existEntity);
            result.Data = mappedEntity;
            return result;
        }

        public async Task<Result<HashSet<DepartmentDto>>> GetAllDepartment()
        {
            var result = new Result<HashSet<DepartmentDto>>();
            var entities = await _unitWork.GetRepository<Department>().GetAllAsync();
            var mappedEnties = _mapper.Map<HashSet<DepartmentDto>>(entities);
            result.Data = mappedEnties; result.Success = true; return result;
        }

        public async Task<Result<DepartmentDto>> GetDepartmentByName(string name)
        {
            var result = new Result<DepartmentDto>();
            var existEntity = await _unitWork.GetRepository<Department>().AnyAsync(x => x.Name.ToUpper().Trim() == name.ToUpper().Trim());
            if (!existEntity)
            {
                throw new NotFoundException("Bu isimle bir Departman bulunamadı.");
            }
            var entity = await _unitWork.GetRepository<Department>().GetByFilterAsync(x => x.Name.ToUpper().Trim() == name.ToUpper().Trim());
            var mappedEntity = _mapper.Map<DepartmentDto>(entity);
            result.Data = mappedEntity;
            return result;
        }

        [Validator(typeof(UpdateDepartmanValidator))]
        public async Task<Result<bool>> UpdateDepartment(UpdateDepartmentRM updateDepartmentRM)
        {
            var result = new Result<bool>();
            var existEntity = await _unitWork.GetRepository<Department>().AnyAsync(x => x.Id == updateDepartmentRM.Id);
            if (!existEntity)
            {
                throw new NotFoundException("Güncellenmek istenen Departman kaydı bulunamadı.");
            }
            var entity = await _unitWork.GetRepository<Department>().GetById(updateDepartmentRM.Id);
            var mappedEntity = _mapper.Map(updateDepartmentRM, entity);
            _unitWork.GetRepository<Department>().Update(mappedEntity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }
    }
}
