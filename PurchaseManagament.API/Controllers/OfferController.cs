using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Offers;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.API.Controllers
{
    [Route("Offer")]
    [Authorize]
    public class OfferController : Controller
    {
        private readonly IOfferService _offerService;

        public OfferController(IOfferService offerService)
        {
            _offerService = offerService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateOffer([FromBody] CreateOfferRM create)
        {
            var entity = await _offerService.CreateOffer(create);
            return Ok(entity);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateOffer([FromBody] UpdateOfferRM update)
        {
            var entity = await _offerService.UpdateOffer(update);
            return Ok(entity);
        }

        [HttpPut("UpdateOfferState")]
        [Authorize(Roles = "1,2,7,8,9")]
        public async Task<IActionResult> UpdateOfferState([FromBody] UpdateOfferStateRM update)
        {
            var entity = await _offerService.UpdateOfferState(update);
            return Ok(entity);
        }

        [HttpGet("GetById/{id}")]
        [Authorize]
        public async Task<ActionResult<Result<OfferDto>>> GetOfferById(Int64 id)
        {
            var result = await _offerService.GetOfferById(new GetOfferByIdRM { Id = id });
            return Ok(result);
        }

        [HttpGet("GetByRequestId/{id}")]
        [Authorize]
        public async Task<ActionResult<Result<OfferDto>>> GetAllOfferByRequestId(Int64 id)
        {
            var result = await _offerService.GetAllOfferByRequestId(new GetOfferByIdRM { Id = id });
            return Ok(result);
        }

        [HttpGet("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetAllDepartment()
        {
            var result = await _offerService.GetAllOffer();
            return Ok(result);
        }

        [HttpGet("GetByManager/{id}")]
        [Authorize]
        public IActionResult GetByManager(int id)
        {
            var result = _offerService.GetOfferByManager(new GetOfferByIdRM { Id = id });
            return Ok(result);
        }

        [HttpGet("GetByChairman/{id}")]
        [Authorize]
        public IActionResult GetOfferByChairman(int id)
        {
            var result = _offerService.GetOfferByChairman(new GetOfferByIdRM { Id = id });
            return Ok(result);
        }

        [HttpGet("GetByAproved/{id}")]
        [Authorize]
        public IActionResult GetOfferByAproved(int id)
        {
            var result = _offerService.GetOfferByAproved(new GetOfferByIdRM { Id = id });
            return Ok(result);
        }

        [HttpGet("GetFromStock/{id}")]
        [Authorize]
        public IActionResult GetOfferFromStock(int id)
        {
            var result = _offerService.GetOfferFromStock(new GetOfferByIdRM { Id = id });
            return Ok(result);
        }

        [HttpPut("Delete/{id}")]
        [Authorize(Roles = "1,2,7,8")]
        public async Task<IActionResult> DeleteOffer(Int64 id)
        {
            var entity = await _offerService.DeleteOffer(new GetByIdVM { Id = id });
            return Ok(entity);
        }

        [HttpDelete("DeletePermanent/{id}")]
        [Authorize(Roles = "1,2,7,8")]
        public async Task<ActionResult<Result<bool>>> DeleteOfferPermanent(Int64 id)
        {
            var result = await _offerService.DeleteOfferPermanent(new GetByIdVM { Id = id });
            return Ok(result);
        }
    }
}
