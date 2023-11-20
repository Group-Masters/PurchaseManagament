using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Report;
using PurchaseManagament.Application.Concrete.Services.PDFServices;
using PurchaseManagament.Application.Concrete.Wrapper;

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
        public async Task<Result<bool>> GenerateReportToPDFByEmploye([FromBody] GetByIdVM getByIdVM)
        {

            var result = new Result<bool>();
            await _reportToPdfService.GenerateReportToPDFByEmploye(getByIdVM);

            result.Success = true;
            result.Data = true;
            return result;
        }

        [HttpPost("GenerateReportToPDFByCompany")]
        public async Task<Result<bool>> GenerateReportToPDFByCompany([FromBody] GetByIdVM getByIdVM)
        {
            var result = new Result<bool>();
            await _reportToPdfService.GenerateReportToPDFByCompany(getByIdVM);

            result.Success = true;
            result.Data = true;
            return result;
        }


        [HttpPost("GenerateReportToPDFByDepartman")]
        public async Task<Result<bool>> GenerateReportToPDFByDepartman([FromBody] GetReportDepartmentVM getByIdVM)
        {
            var result = new Result<bool>();

            await _reportToPdfService.GenerateReportToPDFByDepartman(getByIdVM);
            result.Success = true;
            result.Data = true;
            return result;
        }

        [HttpPost("GenerateReportToPDFByProduct")]
        public async Task<Result<bool>> GenerateReportToPDFByProduct([FromBody] GetReportProductVM getReportProductVM)
        {
            var result = new Result<bool>();

            await _reportToPdfService.GenerateReportToPDFByProduct(getReportProductVM);
            result.Success = true;
            result.Data = true;
            return result;
        }


        [HttpPost("GenerateReportToPDFBySupplier")]
        public async Task<Result<bool>> GenerateReportToPDFBySupplier([FromBody] GetReportSupplierVM getByIdVM)
        {
            var result = new Result<bool>();

            await _reportToPdfService.GenerateReportToPDFBySupplier(getByIdVM);
            result.Success = true;
            result.Data = true;
            return result;
        }

        [HttpPost("GenerateReportToPDFByRequest")]
        public async Task<Result<bool>> GenerateReportToPDFByRequest([FromBody] GetByIdVM getByIdVM)
        {
            var result = new Result<bool>();

            await _reportToPdfService.GenerateReportToPDFByRequest(getByIdVM);
            result.Success = true;
            result.Data = true;
            return result;
        }
    }
}
