using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Pages;

namespace PurchaseManagament.API.Controllers
{
    [Route("Page")]
    [Authorize]
    public class PageController : Controller
    {
        private readonly IPageService _service;

        public PageController(IPageService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetMainChart()
        {
            var entities = await _service.GetAllPage();
            return Ok(entities);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreatePage(CreatePageVM createPageVM)
        {
            var result = await _service.CreatePage(createPageVM);
            return Ok(result);
        }
        


    }
}
