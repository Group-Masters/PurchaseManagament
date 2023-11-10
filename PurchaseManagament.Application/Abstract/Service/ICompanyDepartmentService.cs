using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyDepartments;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.Application.Abstract.Service
{
    public interface ICompanyDepartmentService
    {
        //CRUD
        Task<Result<bool>> CreateCompanyDepartment(CreateCompanyDepartmanRM createCompanyDepartmentRM);
        Task<Result<bool>> UpdateCompanyDepartment(UpdateCompanyDepartmentRM updateCompanyDepartmentRM);
        Task<Result<bool>> DeleteCompanyDepartmentPermanent(GetByIdVM  id);
        Task<Result<bool>> DeleteCompanyDepartment(GetByIdVM id);
        //GET METHODS
        Task<Result<HashSet<DepartmentDto>>> GetDepartmentByCompanyId(GetDepartmentByCompanyIdRM getDepartmentByCompanyIdRM);
        Task<Result<CompanyDepartmentDto>> GetCompanyDepartmentById(GetCompanyDepartmentByIdRM getCompanyDepartmentById);
        Task<Result<HashSet<CompanyDepartmentDto>>> GetAllCompanyDepartment();
    }
}
