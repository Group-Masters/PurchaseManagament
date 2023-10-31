using Microsoft.AspNetCore.Mvc;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Companies;

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
        [HttpPost("GetByName")]
        public async Task<IActionResult> GetCompanyDepartmentByName(string name)
        {
            var entity = await _companyService.GetCompanyByName(name);
            return Ok(entity);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateDepartment([FromBody] UpdateCompanyRM update)
        {
            var entity = await _companyService.UpdateCompany(update);
            return Ok(entity);
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteDepartment(Int64 id)
        {
            var entity = await _companyService.DeleteCompany(new DeleteCompanyRM { Id=id});
            return Ok(entity);
        }
    }
}
