using AutoMapper;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyDepartments;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Persistence.Abstract.UnitWork;

namespace PurchaseManagament.Application.Concrete.Services
{
    public class CompanyDepartmentService : ICompanyDepartmentService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;

        public CompanyDepartmentService(IMapper mapper, IUnitWork unitWork)
        {
            _mapper = mapper;
            _unitWork = unitWork;
        }

        public async Task<Result<bool>> CreateCompanyDepartment(CreateCompanyDepartmentRM createCompanyDepartmentRM)
        {
            var result = new Result<bool>();
            var mappedEntity = _mapper.Map<CompanyDepartment>(createCompanyDepartmentRM);
            _unitWork.GetRepository<CompanyDepartment>().Add(mappedEntity);
            var resultBool = await _unitWork.CommitAsync();
            result.Data = resultBool;
            return result;
        }

        public async Task<Result<bool>> DeleteCompanyDepartment(Int64 id)
        {
            var result = new Result<bool>();
            var existEntity = await _unitWork.GetRepository<CompanyDepartment>().AnyAsync(x => x.Id == id);
            if (!existEntity)
            {
                throw new Exception("Böyle bir ıd silinmek için bulunamadı.");
            }
            var entity = await _unitWork.GetRepository<CompanyDepartment>().GetById(id);
            _unitWork.GetRepository<CompanyDepartment>().Delete(entity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        public async Task<Result<HashSet<CompanyDepartmentDto>>> GetAllCompanyDepartment()
        {
            var result = new Result<HashSet<CompanyDepartmentDto>>();
            var entities = await _unitWork.GetRepository<CompanyDepartment>().GetAllAsync();
            var mappedEntity = _mapper.Map<HashSet<CompanyDepartmentDto>>(entities);
            result.Data = mappedEntity;
            return result;
        }

        public async Task<Result<CompanyDepartmentDto>> GetCompanyDepartmentById(GetCompanyDepartmentByIdRM getCompanyDepartmentById)
        {
            var result = new Result<CompanyDepartmentDto>();
            var entityControl = await _unitWork.GetRepository<CompanyDepartment>().AnyAsync(x => x.Id == getCompanyDepartmentById.Id);
            if (!entityControl)
            {
                throw new Exception($"Departman ID {getCompanyDepartmentById.Id} bulunamadı.");
            }

            var existEntity = await _unitWork.GetRepository<CompanyDepartment>().GetById(getCompanyDepartmentById.Id);
            var mappedEntity = _mapper.Map<CompanyDepartmentDto>(existEntity);
            result.Data = mappedEntity;
            return result;
        }

        public async Task<Result<bool>> UpdateCompanyDepartment(UpdateCompanyDepartmentRM updateCompanyDepartmentRM)
        {
            var result = new Result<bool>();
            var existEntity = await _unitWork.GetRepository<CompanyDepartment>().AnyAsync(x => x.DepartmentId == updateCompanyDepartmentRM.DepartmentId);
            if (!existEntity)
            {
                throw new Exception("Bu id ye sahip bir şirket bulunamadı.");
            }
            var entity = await _unitWork.GetRepository<CompanyDepartment>().GetById(updateCompanyDepartmentRM.DepartmentId);
            var mappedEntity = _mapper.Map(updateCompanyDepartmentRM, entity);
            _unitWork.GetRepository<CompanyDepartment>().Update(mappedEntity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }
    }
}
