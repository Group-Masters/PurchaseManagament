using Microsoft.AspNetCore.Mvc;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Models.RequestModels.MaterialOffers;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Materials;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.API.Controllers
{
    [Route("MaterialOffer")]

    public class MaterialOfferController : Controller
    {
        private readonly IMaterialOfferService _materialOfferService;

        public MaterialOfferController(IMaterialOfferService materialOfferService)
        {
            _materialOfferService = materialOfferService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateMaterialOffer([FromBody] CreateMaterialOfferRM createMaterialOfferRM)
        {
            var result = await _materialOfferService.CreateMaterialOffer(createMaterialOfferRM);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateMaterialOffer([FromBody] UpdateMaterialOfferRM update)
        {
            var entity = await _materialOfferService.UpdateMaterialOffer(update);
            return Ok(entity);
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<Result<MaterialOfferDto>>> GetMaterialOfferById(Int64 id)
        {
            var result = await _materialOfferService.GetMaterialOfferById(new GetByIdVM { Id = id });
            return Ok(result);
        }

        [HttpGet("GetByRequestId/{requestid}")]
        public async Task<ActionResult<Result<HashSet<MaterialOfferDto>>>> GetMaterialOfferByRequestId(Int64 requestId)
        {
            var result = await _materialOfferService.GetMaterialOfferByRequestId(new GetByIdVM { Id = requestId });
            return Ok(result);
        }

        [HttpGet("GetByOfferId/{offerid}")]
        public async Task<ActionResult<Result<HashSet<MaterialOfferDto>>>> GetMaterialOfferByOfferId(Int64 offerId)
        {
            var result = await _materialOfferService.GetMaterialOfferByOfferId(new GetByIdVM { Id = offerId });
            return Ok(result);
        }

        [HttpGet("GetByMaterialId/{materialid}")]
        public async Task<ActionResult<Result<HashSet<MaterialOfferDto>>>> GetMaterialOfferByMaterialId(Int64 materialId)
        {
            var result = await _materialOfferService.GetMaterialOfferByMaterialId(new GetByIdVM { Id = materialId });
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllMaterialOffer()
        {
            var result = await _materialOfferService.GetAllMaterialOffer();
            return Ok(result);
        }

        [HttpPut("Delete/{id}")]
        public async Task<IActionResult> DeleteMaterialOffer(Int64 id)
        {
            var result = await _materialOfferService.DeleteMaterialOffer(new GetByIdVM { Id = id });
            return Ok(result);
        }

        [HttpDelete("DeleteMaterialOffer/{id}")]
        public async Task<ActionResult<Result<bool>>> DeleteMaterialOfferPermanent(Int64 id)
        {
            var result = await _materialOfferService.DeleteMaterialOfferPermanent(new GetByIdVM { Id = id });
            return Ok(result);
        }
    }
}
