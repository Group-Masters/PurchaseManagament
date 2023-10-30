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
        [HttpPost("CreateCompany")]
        public async Task<IActionResult> CreateCompany(CreateCompanyRM createCompanyRM)
        {
           var entities = await _companyService.CreateCompany(createCompanyRM);
            return Ok(entities);
        }

        [HttpGet("GetAllCompany")]
        public async Task<IActionResult> GetAllCompany()
        {
            var entities = await _companyService.GetAllCompany();
            return Ok(entities);
        }
    }
}
