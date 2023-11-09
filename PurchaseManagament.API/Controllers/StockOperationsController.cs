using Microsoft.AspNetCore.Mvc;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;

namespace PurchaseManagament.API.Controllers
{
    [Route("StockOperations")]
    public class StockOperationsController : ControllerBase
    {
        private readonly IStockOperationsService _stockOperationsServiceService;

        public StockOperationsController(IStockOperationsService stockOperationsService)
        {
            _stockOperationsServiceService = stockOperationsService;
        }

        [HttpGet("GetByEmployee/{Id}")]
        public async Task<IActionResult> GetByEmployee(Int64 Id)
        {
            var entities = await _stockOperationsServiceService.GetStockOperationsByEmployeeId(new GetByIdVM { Id = Id });
            return Ok(entities);
        }

        [HttpGet("GetByDepartment/{Id}")]
        public async Task<IActionResult> GetByDepartment(Int64 Id)
        {
            var entities = await _stockOperationsServiceService.GetStockOperationsByDepartmentId(new GetByIdVM { Id = Id });
            return Ok(entities);
        }

        [HttpGet("GetByCompany/{Id}")]
        public async Task<IActionResult> GetByCompany(Int64 Id)
        {
            var entities = await _stockOperationsServiceService.GetStockOperationsByCompanyId(new GetByIdVM { Id = Id });
            return Ok(entities);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllStockOperations()
        {
            var entities = await _stockOperationsServiceService.GetAllStockOperations();
            return Ok(entities);
        }
    }
}
