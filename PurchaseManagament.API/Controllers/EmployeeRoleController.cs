﻿using Microsoft.AspNetCore.Mvc;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.EmployeeRoles;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.API.Controllers
{
    [Route("EmployeeRole")]
    public class EmployeeRoleController : ControllerBase
    {
        private IEmployeeRoleService _employeeRoleService;

        public EmployeeRoleController(IEmployeeRoleService employeeRoleService)
        {
            _employeeRoleService = employeeRoleService;
        }

        [HttpPost("CreateEmployeeRole")]
        public async Task<ActionResult<Result<bool>>> CreateEmployeeRole(CreateEmployeeRoleRM createEmployeeRoleVM)
        {
            var result = await _employeeRoleService.CreateEmployeeRole(createEmployeeRoleVM);
            return Ok(result);
        }

        //Istenmeyen Ozellik
        //[HttpPut("UpdateEmployeeRole")]
        //public async Task<ActionResult<Result<bool>>> UpdateEmployeeRole(UpdateEmployeeRoleRM updateEmployeeRoleVM)
        //{
        //    var result = await _employeeRoleService.UpdateEmployeeRole(updateEmployeeRoleVM);
        //    return Ok(result);
        //}

        [HttpGet("GetById")]
        public async Task<ActionResult<Result<EmployeeRoleDto>>> GetEmployeeRoleById(Int64 Id)
        {
            var result = await _employeeRoleService.GetEmployeeRoleById(new GetEmployeeRoleByIdRM { Id = Id });
            return Ok(result);
        }

        [HttpGet("GetByEmployeeId")]
        public async Task<ActionResult<Result<HashSet<EmployeeRoleDto>>>> GetByEmployeeId(Int64 EmployeeId)
        {
            var result = await _employeeRoleService.GetByEmployeeId(new GetByEmployeeIdRM { EmployeeId = EmployeeId });
            return Ok(result);
        }

        [HttpGet("GetByRoleId")]
        public async Task<ActionResult<Result<HashSet<EmployeeRoleDto>>>> GetByRoleId(Int64 RoleId)
        {
            var result = await _employeeRoleService.GetByRoleId(new GetByRoleIdRM { RoleId = RoleId });
            return Ok(result);
        }

        [HttpGet("GetAllEmployeeRole")]
        public async Task<ActionResult<Result<HashSet<EmployeeRoleDto>>>> GetAllEmployeeRole()
        {
            var result = await _employeeRoleService.GetAllEmployeeRole();
            return Ok(result);
        }

        [HttpPut("DeleteEmployeeRole")]
        public async Task<ActionResult<Result<bool>>> DeleteEmployeeRole(Int64 Id)
        {
            var result = _employeeRoleService.DeleteEmployeeRole(Id);
            return Ok(result);
        }

        [HttpDelete("DeletePermanentEmployeeRole")]
        public async Task<ActionResult<Result<bool>>> DeleteEmployeeRolePermanent(Int64 Id)
        {
            var result = _employeeRoleService.DeleteEmployeeRolePermanent(Id);
            return Ok(result);
        }
    }
}
