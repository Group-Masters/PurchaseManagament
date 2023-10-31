using Microsoft.AspNetCore.Mvc;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyDepartments;

namespace PurchaseManagament.API.Controllers
{
    [Route("CompanyDepartment")]
    public class CompanyDepartmentController : Controller
    {
        private readonly ICompanyDepartmentService _companyDepartmentService;

        public CompanyDepartmentController(ICompanyDepartmentService companyDepartmentService)
        {
            _companyDepartmentService = companyDepartmentService;
        }

        [HttpGet("GetAllCompanyDepartment")]
        public async Task<IActionResult> GetAllDepartment()
        {
            var entities = await _companyDepartmentService.GetAllCompanyDepartment();
            return Ok(entities);
        }
        [HttpPost("GetCompanyDepartmentByName")]
        public async Task<IActionResult> GetCompanyDepartmentByName(string name)
        {
            var entity = await _companyDepartmentService.GetCompanyDepartmentByName(name);
            return Ok(entity);
        }
        [HttpPut("UpdateCompanyDepartment")]
        public async Task<IActionResult> UpdateDepartment(UpdateCompanyDepartmentRM update)
        {
            var entity = await _companyDepartmentService.UpdateCompanyDepartment(update);
            return Ok(entity);
        }
        [HttpDelete("DeleteCompanyDepartment")]
        public async Task<IActionResult> DeleteDepartment(DeleteCompanyDepartmentRM delete)
        {
            var entity = await _companyDepartmentService.DeleteCompanyDepartment(delete);
            return Ok(entity);
        }
        [HttpPost("CreateCompanyDepartment")]
        public async Task<IActionResult> CreateDepartment(CreateCompanyDepartmentRM create)
        {
            var entity = await _companyDepartmentService.CreateCompanyDepartment(create);
            return Ok(entity);
        }
    }
}
