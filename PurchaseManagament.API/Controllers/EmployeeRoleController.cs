﻿using Microsoft.AspNetCore.Mvc;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Models.RequestModels.EmployeeRoles;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.API.Controllers
{
    [Route("EmployeeRole")]
    public class EmployeeRoleController : ControllerBase
    {
        private readonly IEmployeeRoleService _employeeRoleService;

        public EmployeeRoleController(IEmployeeRoleService employeeRoleService)
        {
            _employeeRoleService = employeeRoleService;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<Result<bool>>> CreateEmployeeRole([FromBody] CreateEmployeeRoleRM createEmployeeRoleVM)
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

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<Result<EmployeeRoleDto>>> GetEmployeeRoleById(Int64 Id)
        {
            var result = await _employeeRoleService.GetEmployeeRoleById(new GetEmployeeRoleByIdRM { Id = Id });
            return Ok(result);
        }

        [HttpGet("GetByEmployeeId/{id}")]
        public async Task<ActionResult<Result<HashSet<EmployeeRoleDto>>>> GetByEmployeeId(Int64 EmployeeId)
        {
            var result = await _employeeRoleService.GetByEmployeeId(new GetByEmployeeIdRM { EmployeeId = EmployeeId });
            return Ok(result);
        }

        [HttpGet("GetByRoleId/{id}")]
        public async Task<ActionResult<Result<HashSet<EmployeeRoleDto>>>> GetByRoleId(Int64 RoleId)
        {
            var result = await _employeeRoleService.GetByRoleId(new GetByRoleIdRM { RoleId = RoleId });
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<Result<HashSet<EmployeeRoleDto>>>> GetAllEmployeeRole()
        {
            var result = await _employeeRoleService.GetAllEmployeeRole();
            return Ok(result);
        }

        [HttpGet("GetDetailById/{id}")]
        public async Task<ActionResult<Result<EmployeeRoleDetailDto>>> GetEmployeeRoleDetailById(Int64 Id)
        {
            var result = await _employeeRoleService.GetEmployeeRoleDetailById(new GetEmployeeRoleByIdRM { Id = Id });
            return Ok(result);
        }

        [HttpGet("GetDetailByCompanyId/{id}")]
        public async Task<ActionResult<Result<HashSet<EmployeeRoleDetailDto>>>> GetEmployeeRolesByCompanyId(Int64 Id)
        {
            var result = await _employeeRoleService.GetEmployeeRolesByCompanyId(new GetEmployeeRoleByIdRM { Id = Id });
            return Ok(result);
        }

        [HttpGet("GetAllDetail")]
        public async Task<ActionResult<Result<HashSet<EmployeeRoleDetailDto>>>> GetAllEmployeeRoleDetail()
        {
            var result = await _employeeRoleService.GetAllEmployeeRoleDetail();
            return Ok(result);
        }

        [HttpPut("Delete")]
        public async Task<ActionResult<Result<bool>>> DeleteEmployeeRole(Int64 id)
        {
            var result = await _employeeRoleService.DeleteEmployeeRole(new GetByIdVM { Id = id });
            return Ok(result);
        }

        [HttpDelete("DeletePermanent/{id}")]
        public async Task<ActionResult<Result<bool>>> DeleteEmployeeRolePermanent(Int64 id)
        {
            var result = await _employeeRoleService.DeleteEmployeeRolePermanent(new GetByIdVM { Id = id });
            return Ok(result);
        }
    }
}
