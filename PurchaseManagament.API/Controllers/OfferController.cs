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
    //[Authorize]
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
        //[Authorize(Roles = "1,2,7,8,9")]
        public async Task<IActionResult> UpdateOfferState([FromBody] UpdateOfferStateRM update)
        {
            var entity = await _offerService.UpdateOfferState(update);
            return Ok(entity);
        }

        [HttpPut("UpdateAboveThreshold/{id}")]
        public async Task<IActionResult> UpdateAboveThreshold(Int64 id)
        {
            var entity = await _offerService.UpdateAboveThreshold(new GetOfferByIdRM { Id = id });
            return Ok(entity);
        }

        [HttpGet("GetById/{id}")]
        //[Authorize]
        public async Task<ActionResult<Result<OfferDto>>> GetOfferById(Int64 id)
        {
            var result = await _offerService.GetOfferById(new GetOfferByIdRM { Id = id });
            return Ok(result);
        }

        [HttpGet("GetByRequestId/{id}")]
        //[Authorize]
        public async Task<ActionResult<Result<OfferDto>>> GetAllOfferByRequestId(Int64 id)
        {
            var result = await _offerService.GetAllOfferByRequestId(new GetOfferByIdRM { Id = id });
            return Ok(result);
        }

        [HttpGet("GetAll")]
        //[Authorize]
        public async Task<IActionResult> GetAllOffer()
        {
            var result = await _offerService.GetAllOffer();
            return Ok(result);
        }

        [HttpGet("GetByManager/{id}")]
        //[Authorize]
        public async Task<IActionResult> GetByManager(int id)
        {
            var result = await _offerService.GetOfferByManager(new GetOfferByIdRM { Id = id });
            return Ok(result);
        }

        [HttpGet("GetByChairman/{id}")]
        //[Authorize]
        public async Task<IActionResult> GetOfferByChairman(int id)
        {
            var result = await _offerService.GetOfferByChairman(new GetOfferByIdRM { Id = id });
            return Ok(result);
        }        
        
        [HttpGet("GetByCompany/{id}")]
        //[Authorize]
        public async Task<IActionResult> GetOfferByCompany(int id)
        {
            var result = await _offerService.GetOfferByCompany(new GetOfferByIdRM { Id = id });
            return Ok(result);
        }

        [HttpGet("GetByAproved/{id}")]
        //[Authorize]
        public async Task<IActionResult> GetOfferByAproved(int id)
        {
            var result = await _offerService.GetOfferByAproved(new GetOfferByIdRM { Id = id });
            return Ok(result);
        }

        [HttpGet("GetFromStock/{id}")]
        //[Authorize]
        public async Task<IActionResult> GetOfferFromStock(int id)
        {
            var result = await _offerService.GetOfferFromStock(new GetOfferByIdRM { Id = id });
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
