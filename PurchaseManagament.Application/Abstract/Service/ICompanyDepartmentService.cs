using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyDepartments;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.Application.Abstract.Service
{
    public interface ICompanyDepartmentService
    {
        //CRUD
        Task<Result<bool>> CreateCompanyDepartment(CreateCompanyDepartmentRM createCompanyDepartmentRM);
        Task<Result<bool>> UpdateCompanyDepartment(UpdateCompanyDepartmentRM updateCompanyDepartmentRM);
        Task<Result<bool>> DeleteCompanyDepartmentPermanent(Int64  id);
        Task<Result<bool>> DeleteCompanyDepartment(Int64 id);
        //GET METHODS
        Task<Result<HashSet<DepartmentDto>>> GetDepartmentByCompanyId(GetDepartmentByCompanyIdRM getDepartmentByCompanyIdRM);
        Task<Result<CompanyDepartmentDto>> GetCompanyDepartmentById(GetCompanyDepartmentByIdRM getCompanyDepartmentById);
        Task<Result<HashSet<CompanyDepartmentDto>>> GetAllCompanyDepartment();
    }
}
