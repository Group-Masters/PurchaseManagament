﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyDepartments;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.API.Controllers
{
    [Route("CompanyDepartment")]
    [Authorize]
    public class CompanyDepartmentController : Controller
    {
        private readonly ICompanyDepartmentService _companyDepartmentService;

        public CompanyDepartmentController(ICompanyDepartmentService companyDepartmentService)
        {
            _companyDepartmentService = companyDepartmentService;
        }

        [HttpPost("Create")]
        [Authorize(Roles ="1")]
        public async Task<IActionResult> CreateDepartment([FromBody] CreateCompanyDepartmanRM create)
        {
            var entity = await _companyDepartmentService.CreateCompanyDepartment(create);
            return Ok(entity);
        }

        //[HttpPut("Update")]
        //public async Task<IActionResult> UpdateDepartment([FromBody] UpdateCompanyDepartmentRM update)
        //{
        //    var entity = await _companyDepartmentService.UpdateCompanyDepartment(update);
        //    return Ok(entity);
        //}

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<Result<CompanyDepartmentDto>>> GetCompanyDepartmentById(Int64 id)
        {
            var result = await _companyDepartmentService.GetCompanyDepartmentById(new GetCompanyDepartmentByIdRM { Id = id });
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllDepartment()
        {
            var result = await _companyDepartmentService.GetAllCompanyDepartment();
            return Ok(result);
        }

        [HttpGet("GetDepartmentByCompanyId/{id}")]
        public async Task<ActionResult<Result<HashSet<DepartmentDto>>>> GetDepartmentByCompanyId(Int64 id )
        {
            var result = await _companyDepartmentService.GetDepartmentByCompanyId(new GetDepartmentByCompanyIdRM { CompanyId = id });
            return Ok(result);
        }

        [HttpPut("Delete/{id}")]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> DeleteCompanyDepartment(Int64 id)
        {
            var result = await _companyDepartmentService.DeleteCompanyDepartment(new GetByIdVM { Id = id });
            return Ok(result);
        }

        [HttpDelete("DeletePermanent/{id}")]
        [Authorize(Roles = "1")]
        public async Task<ActionResult<Result<bool>>> DeleteCompanyDepartmentPermanent(Int64 id)
        {
            var result = await _companyDepartmentService.DeleteCompanyDepartmentPermanent(new GetByIdVM { Id = id });
            return Ok(result);
        }
    }
}
