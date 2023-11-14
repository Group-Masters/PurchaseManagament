using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.RequestModels.ImgProduct;
using PurchaseManagament.Application.Concrete.Services;
using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.API.Controllers
{
    [Route("ImgProduct")]
    public class ImgProductController : Controller
    {
        private readonly IImgProductService _imgProductService;

        public ImgProductController(IImgProductService imgProductService)
        {
            _imgProductService = imgProductService;
        }

        [HttpPost("createProduct")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateProduct([FromBody] CreateImgProductRM ımgProduct)
        {
            var entity = await _imgProductService.CreateImgProduct(ımgProduct);

            return Ok(entity);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllImgProduct()
        {
            var entities = await _imgProductService.GetAllImgProduct();
            return Ok(entities);
        }
    }
}
