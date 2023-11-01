using Microsoft.AspNetCore.Mvc;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Products;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Request;
using PurchaseManagament.Application.Concrete.Services;
using PurchaseManagament.Application.Concrete.Wrapper;

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

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateRequestRM update)
        {
            var entity = await _requestService.UpdateRequest(update);
            return Ok(entity);
        }

        [HttpPut("UpdateProductState")]
        public async Task<IActionResult> UpdateProductState([FromBody] UpdateRequestStateRM update)
        {
            var entity = await _requestService.UpdateRequestState(update);
            return Ok(entity);
        }


        [HttpGet("GetAllRequest")]
        public async Task<IActionResult> GetAllRequest()
        {
            var entities = await _requestService.GetAllRequest();
            return Ok(entities);
        }

        [HttpPut("Delete/{id}")]
        public async Task<IActionResult> UpdateRequest(Int64 id)
        {
            var entity = await _requestService.DeleteRequest(id);
            return Ok(entity);
        }

        [HttpDelete("DeleteRequest/{id}")]
        public async Task<ActionResult<Result<bool>>> DeleteRequestPermanent(Int64 id)
        {
            var result = await _requestService.DeleteRequestPermanent(id);
            return Ok(result);
        }
    }
}
