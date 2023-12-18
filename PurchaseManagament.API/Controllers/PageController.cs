using Microsoft.AspNetCore.Mvc;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Pages;

namespace PurchaseManagament.API.Controllers
{
    [Route("Page")]
    //[Authorize(Roles = "1,7,8")]
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
        //[HttpGet("GetByDepartment/{CompanyId}/{DepartmentId}")]
        //public async Task<IActionResult> GetByDepartment(Int64 CompanyId, Int64 DepartmentId)
        //{
        //    var entities = await _service.GetReportByDepartmentId(new GetReportDepartmentVM { CompanyId=CompanyId,DepartmentId=DepartmentId  });
        //    return Ok(entities);
        //}
        //[HttpGet("GetByCompany/{Id}")]
        //public async Task<IActionResult> GetReportByCompanyId(Int64 Id)
        //{
        //    var entities = await _service.GetReportByCompanyId(new GetByIdVM { Id=Id});
        //    return Ok(entities);
        //}
        //[HttpGet("GetByRequestID/{Id}")]
        //[AllowAnonymous]
        //public async Task<IActionResult> GetRequestReportbyRequestId(Int64 Id)
        //{
        //    var entities = await _service.GetRequestReportbyRequestId(new GetByIdVM { Id=Id});
        //    return Ok(entities);
        //}
        //[HttpGet("GetSupplierById/{companyId}/{supplierId}")]
        //[AllowAnonymous]
        //public async Task<IActionResult> GetSupplierById(Int64 companyId ,Int64 supplierId)
        //{
        //    var entities = await _service.GetSupplierReport(new GetReportSupplierVM { CompanyId = companyId, SupplierId = supplierId });
        //    return Ok(entities);
        //}
        //[HttpGet("GetbyProduct/{idCompany}/{idProduct}")]
        //public async Task<IActionResult> GetReportByProduct(Int64 idCompany,Int64 idProduct)
        //{ 
        //    var entities = await _service.GetProductReport(new GetReportProductVM { CompanyId= idCompany,ProductId=idProduct });
        //    return Ok(entities);
        //}


    }
}
