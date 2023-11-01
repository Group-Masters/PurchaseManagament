using Microsoft.AspNetCore.Mvc;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Products;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.API.Controllers
{
    [Route("Product")]
        public class ProductController : Controller
        {
            private readonly IProductService _productService;

            public ProductController(IProductService ProductService)
            {
                _productService = ProductService;
            }

            [HttpPost("CreateProduct")]
            public async Task<IActionResult> CreateProduct([FromBody] CreateProductRM createProductRM)
            {
                var entity = await _productService.CreateProduct(createProductRM);
                return Ok(entity);
            }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductRM update)
        {
            var entity = await _productService.UpdateProduct(update);
            return Ok(entity);              
        }

        [HttpGet("GetAllProduct")]
            public async Task<IActionResult> GetAllProduct()
            {
                var entities = await _productService.GetAllProduct();
                return Ok(entities);
            }

            [HttpPut("Delete/{id}")]
            public async Task<IActionResult> DeleteProduct(Int64 id)
            {
            var entity = await _productService.DeleteProduct(id);
                return Ok(entity);
            }

            [HttpDelete("DeletePermanent/{id}")]
            public async Task<ActionResult<Result<bool>>> DeleteCompanyStockPermanent(Int64 id)
            {
                var result = await _productService.DeleteProductPermanent(id);
                return Ok(result);
            }
        }
}
