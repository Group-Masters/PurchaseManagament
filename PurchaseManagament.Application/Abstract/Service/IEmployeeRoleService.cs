using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.EmployeeRoles;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.Application.Abstract.Service
{
    public interface IEmployeeRoleService
    {
        Task<Result<bool>> CreateEmployeeRole(CreateEmployeeRoleRM createEmployeeRoleRM);
        Task<Result<bool>> UpdateEmployeeRole(UpdateEmployeeRoleRM updateEmployeeRoleRM);
        Task<Result<bool>> DeleteEmployeeRole(Int64 Id);
        Task<Result<bool>> DeleteEmployeeRolePermanent(Int64 Id);

        Task<Result<EmployeeRoleDto>> GetEmployeeRoleById(GetEmployeeRoleByIdRM getEmployeeRoleByIdRM);
        Task<Result<HashSet<EmployeeRoleDto>>> GetByEmployeeId(GetByEmployeeIdRM getByEmployeeIdRM);
        Task<Result<HashSet<EmployeeRoleDto>>> GetByRoleId(GetByRoleIdRM getByRoleIdRM);
        Task<Result<HashSet<EmployeeRoleDto>>> GetAllEmployeeRole();

        Task<Result<EmployeeRoleDetailDto>> GetEmployeeRoleDetailById(GetEmployeeRoleByIdRM getEmployeeRoleByIdRM);
        Task<Result<HashSet<EmployeeRoleDetailDto>>> GetAllEmployeeRoleDetail();
    }
}
