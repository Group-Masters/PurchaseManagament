﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Departments;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.API.Contdepartmanlers
{
    [Route("Department")]
    [Authorize]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpPost("Create")]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentRM create)
        {
            var entity = await _departmentService.CreateDepartment(create);
            return Ok(entity);
        }

        [HttpPut("Update")]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> UpdateDepartment([FromBody] UpdateDepartmentRM updateDepartmentRM)
        {
            var entity = await _departmentService.UpdateDepartment(updateDepartmentRM);
            return Ok(entity);
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<Result<DepartmentDto>>> GetByIdDepartment(Int64 id)
        {
            var result = await _departmentService.GetDepartmentById(new GetByIdDepartmentRM { Id = id });
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllDepartment()
        {
           var entities = await _departmentService.GetAllDepartment();
            return Ok(entities);
        }

        //Istenmeyen Ozellik
        //[HttpPost("GetDepartmentByName")]
        //public async Task<IActionResult> GetDepartmentByName(string name)
        //{
        //    var entity = await _departmentService.GetDepartmentByName(name);
        //    return Ok(entity);
        //}

        [HttpPut("Delete/{id}")]
        [Authorize(Roles = "1")]
        public async Task<ActionResult<Result<bool>>> DeleteDepartment(Int64 id)
        {
            var result = await _departmentService.DeleteDepartment(new GetByIdVM { Id = id });
            return Ok(result);
        }

        [HttpDelete("DeletePermanent/{id}")]
        [Authorize(Roles = "1")]
        public async Task<ActionResult<Result<bool>>> DeleteDepartmentPermanent(Int64 id)
        {
            var result = await _departmentService.DeleteDepartmentPermanent(new GetByIdVM { Id = id });
            return Ok(result);
        }
    }
}
