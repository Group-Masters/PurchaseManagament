using Microsoft.AspNetCore.Mvc;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Roles;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.API.Controllers
{
    [Route("Role")]
    public class RoleController : ControllerBase
    {
        private IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost("CreateRole")]
        public async Task<ActionResult<Result<bool>>> CreateRole(CreateRoleRM createRoleVM)
        {
            var result = await _roleService.CreateRole(createRoleVM);
            return Ok(result);
        }

        [HttpPut("UpdateRole")]
        public async Task<ActionResult<Result<bool>>> UpdateRole(UpdateRoleRM updateRoleVM)
        {
            var result = await _roleService.UpdateRole(updateRoleVM);
            return Ok(result);
        }

        [HttpGet("GetRoleById")]
        public async Task<ActionResult<Result<RoleDto>>> GetRoleById(long id)
        {
            var result = await _roleService.GetRoleById(new GetRoleByIdRM { Id = id });
            return Ok(result);
        }

        [HttpGet("GetRoleByName")]
        public async Task<ActionResult<Result<RoleDto>>> GetRoleByName(string name)
        {
            var result = await _roleService.GetRoleByName(new GetRoleByNameRM { Name = name });
            return Ok(result);
        }

        [HttpGet("GetAllRole")]
        public async Task<ActionResult<Result<HashSet<RoleDto>>>> GetAllRole()
        {
            var result = await _roleService.GetAllRole();
            return Ok(result);
        }

        [HttpPut("DeleteRole")]
        public async Task<ActionResult<Result<bool>>> DeleteRole(long Id)
        {
            var result = _roleService.DeleteRole(Id);
            return Ok(result);
        }

        [HttpDelete("DeletePermanentRole")]
        public async Task<ActionResult<Result<bool>>> DeleteRolePermanent(long Id)
        {
            var result = _roleService.DeleteRolePermanent(Id);
            return Ok(result);
        }
    }
}
