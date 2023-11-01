using Microsoft.AspNetCore.Mvc;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyStocks;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.API.Controllers
{
    [Route("CompanyStock")]
    public class CompanyStockController : Controller
    {
        private readonly ICompanyStockService _companyStockService;

        public CompanyStockController(ICompanyStockService companyStockService)
        {
            _companyStockService = companyStockService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateCompanyStock([FromBody] CreateCompanyStockRM create)
        {
            var entity = await _companyStockService.CreateCompanyStock(create);
            return Ok(entity);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateDepartment([FromBody] UpdateCompanyStockRM update)
        {
            var entity = await _companyStockService.UpdateCompanyStock(update);
            return Ok(entity);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllCompanyStock()
        {
            var entities = await _companyStockService.GetAllCompanyStock();
            return Ok(entities);
        }

        [HttpPut("Delete/{id}")]
        public async Task<IActionResult> DeleteCompanyStock(Int64 id)
        {
            var entity = await _companyStockService.DeleteCompanyStock(id);
            return Ok(entity);
        }

        [HttpDelete("DeletePermanent/{id}")]
        public async Task<ActionResult<Result<bool>>> DeleteCompanyStockPermanent(Int64 id)
        {
            var result = await _companyStockService.DeleteCompanyStockPermanent(id);
            return Ok(result);
        }
    }
}
