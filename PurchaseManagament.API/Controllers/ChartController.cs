using Microsoft.AspNetCore.Mvc;
using PurchaseManagament.Application.Abstract.Service;

namespace PurchaseManagament.API.Controllers
{
    [Route("Chart")]
    //[Authorize(Roles = "1,7,8")]
    public class ChartController : Controller
    {
        private readonly IChartService _service;

        public ChartController(IChartService service)
        {
            _service = service;
        }

        [HttpGet("GetMainChart")]
        public async Task<IActionResult> GetMainChart()
        {
            var entities = await _service.GetMainChart();
            return Ok(entities);
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
