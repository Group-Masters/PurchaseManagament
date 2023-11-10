using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Roles;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.Application.Abstract.Service
{
    public interface IRoleService
    {
        Task<Result<bool>> CreateRole(CreateRoleRM createRoleRM);
        Task<Result<bool>> UpdateRole(UpdateRoleRM updateRoleRM);
        Task<Result<RoleDto>> GetRoleById(GetRoleByIdRM getRoleByIdRM);
        Task<Result<RoleDto>> GetRoleByName(GetRoleByNameRM getRoleByNameRM);
        Task<Result<HashSet<RoleDto>>> GetAllRole();
        Task<Result<bool>> DeleteRole(GetByIdVM Id);
        Task<Result<bool>> DeleteRolePermanent(GetByIdVM Id);
    }
}
