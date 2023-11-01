﻿using Microsoft.AspNetCore.Mvc;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Companies;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.API.Controllers
{
    [Route("Company")]
    public class CompanyController : Controller
    {
        private ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreateCompany([FromBody]CreateCompanyRM createCompanyRM)
        {
           var entities = await _companyService.CreateCompany(createCompanyRM);
            return Ok(entities);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllCompany()
        {
            var entities = await _companyService.GetAllCompany();
            return Ok(entities);
        }
        [HttpGet("GetById")]
        public async Task<ActionResult<Result<CompanyDto>>> GetCompanyById(Int64 id)
        {
            var result = await _companyService.GetCompanyById(new GetCompanyByIdRM { Id = id });
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateDepartment([FromBody] UpdateCompanyRM update)
        {
            var entity = await _companyService.UpdateCompany(update);
            return Ok(entity);
        }
        [HttpPut("Delete/{id}")]
        public async Task<ActionResult<Result<bool>>> DeleteCompany(Int64 id)
        {
            var result = await _companyService.DeleteCompany(id);
            return Ok(result);
        }

        [HttpDelete("DeletePermanent/{id}")]
        public async Task<ActionResult<Result<bool>>> DeleteCompanyPermanent(Int64 id)
        {
            var result = await _companyService.DeleteCompanyPermanent(id);
            return Ok(result);
        }
    }
}
