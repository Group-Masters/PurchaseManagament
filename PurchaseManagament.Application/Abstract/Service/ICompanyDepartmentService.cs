using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyDepartments;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.Application.Abstract.Service
{
    public interface ICompanyDepartmentService
    {
        //CRUD
        Task<Result<bool>> CreateCompanyDepartment(CreateCompanyDepartmentRM createCompanyDepartmentRM);
        Task<Result<bool>> DeleteCompanyDepartment(DeleteCompanyDepartmentRM deleteCompanyDepartmentRM);
        Task<Result<bool>> UpdateCompanyDepartment(UpdateCompanyDepartmentRM updateCompanyDepartmentRM);

        //GET METHODS
        Task<Result<CompanyDepartmentDto>> GetCompanyDepartmentByName(string companyName);
        Task<Result<HashSet<CompanyDepartmentDto>>> GetAllCompanyDepartment();
    }
}
