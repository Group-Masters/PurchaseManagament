using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Report;
using PurchaseManagament.Application.Concrete.Services;
using PurchaseManagament.Application.Concrete.Services.PDFServices;

namespace PurchaseManagament.API.Controllers
{
    [Route("PDF")]
    [Authorize(Roles = "1,7,8")]
    public class RequestToPDFController : Controller
    {
        private readonly ReportToPdfService _reportToPdfService;

        public RequestToPDFController(ReportToPdfService reportToPdfService)
        {
            this._reportToPdfService = reportToPdfService;
        }

        [HttpPost("GenerateReportToPDFByEmploye")]
        public async Task GenerateReportToPDFByEmploye([FromBody] GetByIdVM getByIdVM)
        {
            await _reportToPdfService.GenerateReportToPDFByEmploye(getByIdVM);
        }

        [HttpPost("GenerateReportToPDFByCompany")]
        public async Task GenerateReportToPDFByCompany([FromBody] GetByIdVM getByIdVM)
        {
            await _reportToPdfService.GenerateReportToPDFByCompany(getByIdVM);
        }


        [HttpPost("GenerateReportToPDFByDepartman")]
        public async Task GenerateReportToPDFByDepartman([FromBody] GetReportDepartmentVM getByIdVM)
        {
            await _reportToPdfService.GenerateReportToPDFByDepartman(getByIdVM);
        }

        [HttpPost("GenerateReportToPDFByProduct")]
        public async Task GenerateReportToPDFByProduct([FromBody] GetReportProductVM getReportProductVM)
        {
            await _reportToPdfService.GenerateReportToPDFByProduct(getReportProductVM);
        }


        [HttpPost("GenerateReportToPDFBySupplier")]
        public async Task GenerateReportToPDFBySupplier([FromBody] GetByIdVM getByIdVM)
        {
            await _reportToPdfService.GenerateReportToPDFBySupplier(getByIdVM);
        }
    }
}
