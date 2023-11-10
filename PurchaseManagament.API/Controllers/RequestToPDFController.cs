using Microsoft.AspNetCore.Mvc;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Report;
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
        public async Task GenerateReportToPDFByEmploye([FromBody] GetByIdVM getByIdVM)
        {
            await _reportToPdfService.GenerateReportToPDFByEmploye(getByIdVM);
        }

        [HttpPost("GenerateReportToPDFByCompany")]
        public async Task GenerateReportToPDFByCompany(Int64 id)
        {
            await _reportToPdfService.GenerateReportToPDFByCompany(new GetByIdVM { Id = id });
        }


        [HttpPost("GenerateReportToPDFByDepartman")]
        public async Task GenerateReportToPDFByDepartman(Int64 id)
        {
            await _reportToPdfService.GenerateReportToPDFByDepartman(new GetByIdVM { Id = id });
        }

        [HttpPost("GenerateReportToPDFByProduct")]
        public async Task GenerateReportToPDFByProduct(GetReportProductVM getReportProductVM)
        {
            await _reportToPdfService.GenerateReportToPDFByProduct(new GetReportProductVM { CompanyId = getReportProductVM.CompanyId, ProductId = getReportProductVM.ProductId });
        }


        [HttpPost("GenerateReportToPDFBySupplier")]
        public async Task GenerateReportToPDFBySupplier(Int64 id)
        {
            await _reportToPdfService.GenerateReportToPDFBySupplier(new GetByIdVM { Id = id });
        }
    }
}
