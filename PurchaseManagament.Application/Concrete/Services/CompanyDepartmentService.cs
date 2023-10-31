using AutoMapper;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Companies;
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

        public async Task<Result<bool>> DeleteCompanyDepartment(DeleteCompanyDepartmentRM deleteCompanyDepartmentRM)
        {
            var result = new Result<bool>();
            var existEntity = await _unitWork.GetRepository<CompanyDepartment>().AnyAsync(x => x.Id == deleteCompanyDepartmentRM.Id);
            if (existEntity)
            {
                throw new Exception("Böyle bir ıd silinmek için bulunamadı.");
            }
            var entity = await _unitWork.GetRepository<CompanyDepartment>().GetById(deleteCompanyDepartmentRM.Id);
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

        public async Task<Result<CompanyDepartmentDto>> GetCompanyDepartmentByName(string companyName)
        {
            var result = new Result<CompanyDepartmentDto>();
            var existEntity = await _unitWork.GetRepository<CompanyDepartmentDto>().AnyAsync(x => x.Company.Name.ToUpper().Trim() == companyName.ToUpper().Trim());
            if (existEntity)
            {
                throw new Exception("Bu isimle bir şirket bulunamadı.");
            }
            var entity = await _unitWork.GetRepository<CompanyDepartmentDto>().GetBySpesificFilter(x => x.Company.Name.ToUpper().Trim() == companyName.ToUpper().Trim());
            var mappedEntity = _mapper.Map<CompanyDepartmentDto>(entity);
            result.Data = mappedEntity;
            return result;
        }

        public async Task<Result<bool>> UpdateCompanyDepartment(UpdateCompanyDepartmentRM updateCompanyDepartmentRM)
        {
            var result = new Result<bool>();
            var existEntity = await _unitWork.GetRepository<CompanyDepartmentDto>().AnyAsync(x => x.DepartmentId == updateCompanyDepartmentRM.DepartmentId);
            if (existEntity)
            {
                throw new Exception("Bu id ye sahip bir şirket bulunamadı.");
            }
            var entity = await _unitWork.GetRepository<CompanyDepartmentDto>().GetById(updateCompanyDepartmentRM.DepartmentId);
            var mappedEntity = _mapper.Map(updateCompanyDepartmentRM, entity);
            _unitWork.GetRepository<CompanyDepartmentDto>().Update(mappedEntity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }
    }
}
