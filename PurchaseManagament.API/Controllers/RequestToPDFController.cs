using Microsoft.AspNetCore.Mvc;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Services;
using PurchaseManagament.Application.Concrete.Services.PDFServices;

namespace PurchaseManagament.API.Controllers
{
    [Route("PDF")]
    public class RequestToPDFController : Controller
    {
        private readonly ReportToPdfService _reportToPdfService;

        public RequestToPDFController(ReportToPdfService reportToPdfService)
        {
            this._reportToPdfService = reportToPdfService;
        }

        [HttpPost("GenerateReportToPDFByEmploye")]
        public void GenerateReportToPDFByEmploye(Int64 id)
        {
            _reportToPdfService.GenerateReportToPDFByEmploye(new GetByIdVM { Id = id});
        }
    }
}
