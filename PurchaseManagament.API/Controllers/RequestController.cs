using Microsoft.AspNetCore.Mvc;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Products;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Request;

namespace PurchaseManagament.API.Controllers
{
    [Route("request")]
    public class RequestController : Controller
    {
        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpPost("CreateRequest")]
        public async Task<IActionResult> CreateRequest([FromBody] CreateRequestRM createRequestRM)
        {
            var entity = await _requestService.CreateRequest(createRequestRM);
            return Ok(entity);
        }
    }
}
