using AutoMapper;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Departments;
using PurchaseManagament.Application.Concrete.Wrapper;
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

        public async Task<Result<bool>> CreateDepartment(CreateDepartmentRM createDepartmentRM)
        {
            var result = new Result<bool>();
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

        public async Task<Result<bool>> DeleteDepartment(Int64 id)
        {
            var result = new Result<bool>();
            var existEntity = await _unitWork.GetRepository<Department>().AnyAsync(x => x.Id == id);
            if (!existEntity)
            {
                throw new Exception("Böyle bir ıd silinmek için bulunamadı.");
            }
            var entity = await _unitWork.GetRepository<Department>().GetById(id);
            entity.IsDeleted = true;
            _unitWork.GetRepository<Department>().Update(entity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        public async Task<Result<bool>> DeleteDepartmentPermanent(Int64 id)
        {
            var result = new Result<bool>();
            var existEntity = await _unitWork.GetRepository<Department>().AnyAsync(x => x.Id == id);
            if (!existEntity)
            {
                throw new Exception("Böyle bir ıd silinmek için bulunamadı.");
            }
            var entity = await _unitWork.GetRepository<Department>().GetById(id);
            _unitWork.GetRepository<Department>().Delete(entity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        public async Task<Result<DepartmentDto>> GetDepartmentById(GetByIdDepartmentRM getByIdDepartmentRM)
        {
            var result = new Result<DepartmentDto>();
            var entityControl = await _unitWork.GetRepository<Department>().AnyAsync(x => x.Id == getByIdDepartmentRM.Id);
            if (!entityControl)
            {
                throw new Exception($"Departman ID {getByIdDepartmentRM.Id} bulunamadı.");
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
                throw new Exception("Bu isimle bir şirket bulunamadı.");
            }
            var entity = await _unitWork.GetRepository<Department>().GetByFilterAsync(x => x.Name.ToUpper().Trim() == name.ToUpper().Trim());
            var mappedEntity = _mapper.Map<DepartmentDto>(entity);
            result.Data = mappedEntity;
            return result;
        }

        public async Task<Result<bool>> UpdateDepartment(UpdateDepartmentRM updateDepartmentRM)
        {
            var result = new Result<bool>();
            var existEntity = await _unitWork.GetRepository<Department>().AnyAsync(x => x.Id == updateDepartmentRM.Id);
            if (!existEntity)
            {
                throw new Exception("Bu id ye sahip bir departman bulunamadı.");
            }
            var entity = await _unitWork.GetRepository<Department>().GetById(updateDepartmentRM.Id);
            var mappedEntity = _mapper.Map(updateDepartmentRM, entity);
            _unitWork.GetRepository<Department>().Update(mappedEntity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }
    }
}
