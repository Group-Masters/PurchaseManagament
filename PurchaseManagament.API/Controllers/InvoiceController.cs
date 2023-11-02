using Microsoft.AspNetCore.Mvc;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Invoices;
using PurchaseManagament.Application.Concrete.Models.RequestModels.MeasuringUnits;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.API.Controllers
{
    [Route("Invoice")]
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateInvoice([FromBody] CreateInvoiceRM create)
        {
            var entity = await _invoiceService.CreateInvoice(create);
            return Ok(entity);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateInvoice([FromBody] UpdateInvoiceRM update)
        {
            var entity = await _invoiceService.UpdateInvoice(update);
            return Ok(entity);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllInvoice()
        {
            var entities = await _invoiceService.GetAllInvoice();
            return Ok(entities);
        }

        [HttpPut("Delete/{id}")]
        public async Task<IActionResult> DeleteInvoice(Int64 id)
        {
            var entity = await _invoiceService.DeleteInvoice(id);
            return Ok(entity);
        }

        [HttpDelete("DeletePermanent/{id}")]
        public async Task<ActionResult<Result<bool>>> DeleteInvoicePermanent(Int64 id)
        {
            var result = await _invoiceService.DeleteInvoicePermanent(id);
            return Ok(result);
        }
    }
}
