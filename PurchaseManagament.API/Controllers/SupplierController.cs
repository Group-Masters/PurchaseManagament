using Microsoft.AspNetCore.Mvc;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Suppliers;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.API.Controllers
{
    [Route("Supplier")]
    public class SupplierController : Controller
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreateSupplier([FromBody] CreateSupplierRM createSupplierRM)
        {
            var entities = await _supplierService.CreateSupplier(createSupplierRM);
            return Ok(entities);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateDepartment([FromBody] UpdateSupplierRM update)
        {
            var entity = await _supplierService.UpdateSupplier(update);
            return Ok(entity);
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<Result<SupplierDto>>> GetSupplierById(Int64 id)
        {
            var result = await _supplierService.GetSupplierById(new GetSupplierByIdRM { Id = id });
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllSupplier()
        {
            var entities = await _supplierService.GetAllSupplier();
            return Ok(entities);
        }

        [HttpPut("Delete/{id}")]
        public async Task<ActionResult<Result<bool>>> DeleteSupplier(Int64 id)
        {
            var result = await _supplierService.DeleteSupplier(new GetByIdVM { Id = id });
            return Ok(result);
        }

        [HttpDelete("DeletePermanent/{id}")]
        public async Task<ActionResult<Result<bool>>> DeleteSupplierPermanent(Int64 id)
        {
            var result = await _supplierService.DeleteSupplierPermanent(new GetByIdVM { Id = id });
            return Ok(result);
        }
    }
}
