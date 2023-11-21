using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Companies;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.API.Controllers
{
    [Route("Company")]
    [AllowAnonymous]
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        [HttpPost("Create")]
        [Authorize(Roles ="1")]
        public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyRM createCompanyRM)
        {
           var entities = await _companyService.CreateCompany(createCompanyRM);
            return Ok(entities);
        }

        [HttpPut("Update")]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> UpdateDepartment([FromBody] UpdateCompanyRM update)
        {
            var entity = await _companyService.UpdateCompany(update);
            return Ok(entity);
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<Result<CompanyDto>>> GetCompanyById(Int64 id)
        {
            var result = await _companyService.GetCompanyById(new GetCompanyByIdRM { Id = id });
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllCompany()
        {
            var entities = await _companyService.GetAllCompany();
            return Ok(entities);
        }

        [HttpPut("Delete/{id}")]
        [Authorize(Roles = "1")]
        public async Task<ActionResult<Result<bool>>> DeleteCompany(Int64 id)
        {
            var result = await _companyService.DeleteCompany(new GetByIdVM { Id = id });
            return Ok(result);
        }

        [HttpDelete("DeletePermanent/{id}")]
        [Authorize(Roles = "1")]
        public async Task<ActionResult<Result<bool>>> DeleteCompanyPermanent(Int64 id)
        {
            var result = await _companyService.DeleteCompanyPermanent(new GetByIdVM { Id = id });
            return Ok(result);
        }
    }
}
