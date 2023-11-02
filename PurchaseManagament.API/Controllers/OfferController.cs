﻿using Microsoft.AspNetCore.Mvc;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Offers;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.API.Controllers
{
    [Route("Offer")]
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

        [HttpGet("GetById")]
        public async Task<ActionResult<Result<OfferDto>>> GetOfferById(Int64 id)
        {
            var result = await _offerService.GetOfferById(new GetOfferByIdRM { Id = id });
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllDepartment()
        {
            var result = await _offerService.GetAllOffer();
            return Ok(result);
        }

        [HttpPut("Delete/{id}")]
        public async Task<IActionResult> DeleteOffer(Int64 id)
        {
            var entity = await _offerService.DeleteOffer(id);
            return Ok(entity);
        }

        [HttpDelete("DeletePermanent/{id}")]
        public async Task<ActionResult<Result<bool>>> DeleteOfferPermanent(Int64 id)
        {
            var result = await _offerService.DeleteOfferPermanent(id);
            return Ok(result);
        }
    }
}
