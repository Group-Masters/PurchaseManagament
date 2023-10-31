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

        [HttpPost("Create")]
        public async Task<ActionResult<Result<bool>>> CreateRole([FromBody] CreateRoleRM createRoleVM)
        {
            var result = await _roleService.CreateRole(createRoleVM);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<Result<bool>>> UpdateRole([FromBody] UpdateRoleRM updateRoleVM)
        {
            var result = await _roleService.UpdateRole(updateRoleVM);
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<Result<RoleDto>>> GetRoleById(Int64 id)
        {
            var result = await _roleService.GetRoleById(new GetRoleByIdRM { Id = id });
            return Ok(result);
        }

        //Istenmeyen Ozellik
        //[HttpGet("GetRoleByName")]
        //public async Task<ActionResult<Result<RoleDto>>> GetRoleByName(string name)
        //{
        //    var result = await _roleService.GetRoleByName(new GetRoleByNameRM { Name = name });
        //    return Ok(result);
        //}

        [HttpGet("GetAll")]
        public async Task<ActionResult<Result<HashSet<RoleDto>>>> GetAllRole()
        {
            var result = await _roleService.GetAllRole();
            return Ok(result);
        }

        [HttpPut("Delete/{id}")]
        public async Task<ActionResult<Result<bool>>> DeleteRole(Int64 id)
        {
            var result = await _roleService.DeleteRole(id);
            return Ok(result);
        }

        [HttpDelete("DeletePermanent/{id}")]
        public async Task<ActionResult<Result<bool>>> DeleteRolePermanent(Int64 id)
        {
            var result = await _roleService.DeleteRolePermanent(id);
            return Ok(result);
        }
    }
}
