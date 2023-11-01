using Microsoft.AspNetCore.Mvc;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Currency;
using PurchaseManagament.Application.Concrete.Models.RequestModels.MeasuringUnits;
using PurchaseManagament.Application.Concrete.Services;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.API.Controllers
{
    [Route("currency")]
    public class CurrencyController : Controller
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        [HttpPost("CreateCurrency")]
        public async Task<IActionResult> CreateCurrency([FromBody] CreateCurrencyRM create)
        {
            var entity = await _currencyService.CreateCurrency(create);
            return Ok(entity);
        }

        [HttpPut("Delete/{id}")]
        public async Task<IActionResult> DeleteCurrency(Int64 id)
        {
            var entity = await _currencyService.DeleteCurrency(id);
            return Ok(entity);
        }

        [HttpDelete("DeletePermanent/{id}")]
        public async Task<ActionResult<Result<bool>>> DeleteCurrencyPermanent(Int64 id)
        {
            var result = await _currencyService.DeleteCurrencyPermanent(id);
            return Ok(result);
        }
    }
}
