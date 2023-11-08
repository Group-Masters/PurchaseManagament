﻿using Microsoft.AspNetCore.Mvc;
using PurchaseManagament.Application.Concrete.Models.Dtos;
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

        [HttpPost("GenerateRequestToPDF")]
        public void GenerateToPDF([FromBody] HashSet<ReportDto> reportDtos)
        {
            _reportToPdfService.GeneratePDF(reportDtos);
        }
    }
}
