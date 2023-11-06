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
        private readonly IStockOperationsService _stockOperationsService;

        public CompanyStockController(ICompanyStockService companyStockService, IStockOperationsService stockOperationsService)
        {
            _companyStockService = companyStockService;
            _stockOperationsService = stockOperationsService;
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

        // Adet güncellemesi
        [HttpPut("UpdateQuantity")]
        public async Task<IActionResult> UpdateQuantity([FromBody] UpdateCompanyQuantityRM update)
        {
            var entity = await _companyStockService.UpdateCompanyStockQuantity(update);

            


            return Ok(entity);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllCompanyStock()
        {
            var entities = await _companyStockService.GetAllCompanyStock();
            return Ok(entities);
        }

        [HttpGet("GetAllByCompanyId/{id}")]
        public async Task<IActionResult> GetAllCompanyStockByCompanyId(Int64 id)
        {
            var entities = await _companyStockService.GetAllCompanyStockByCompanyId(id);
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
