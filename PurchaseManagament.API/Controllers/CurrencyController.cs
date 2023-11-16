using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Currency;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.API.Controllers
{
    [Route("Currency")]
    [AllowAnonymous]
    public class CurrencyController : Controller
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }
        [HttpGet("GetAllCurrencyNames")]
        [Authorize(Roles = "1")]
        public IActionResult GetAllCurrencyNames()
        {
            var entity = _currencyService.GetAllCurrencyNames();
            return Ok(entity);
        }
        [HttpPost("Create")]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> CreateCurrency([FromBody] CreateCurrencyRM create)
        {
            var entity = await _currencyService.CreateCurrency(create);
            return Ok(entity);
        }

        [HttpPut("Delete/{id}")]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> DeleteCurrency(Int64 id)
        {
            var entity = await _currencyService.DeleteCurrency(new GetByIdVM { Id = id });
            return Ok(entity);
        }

        [HttpDelete("DeletePermanent/{id}")]
        [Authorize(Roles = "1")]
        public async Task<ActionResult<Result<bool>>> DeleteCurrencyPermanent(Int64 id)
        {
            var result = await _currencyService.DeleteCurrencyPermanent(new GetByIdVM { Id = id });
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllCurrency()
        {
            var entities = await _currencyService.GetAllCurrency();
            return Ok(entities);
        }

        [HttpPut("Update")]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> UpdateCurrency([FromBody] UpdateCurrencyRM update)
        {
            var entity = await _currencyService.UpdateCurrency(update);
            return Ok(entity);
        }
    }
}
