﻿using Microsoft.AspNetCore.Mvc;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Currency;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.API.Controllers
{
    [Route("Report")]
    public class ReportController : Controller
    {
        private readonly IReportService _service;

        public ReportController(IReportService service)
        {
            _service = service;
        }

        [HttpGet("GetByEmployee/{Id}")]
        public async Task<IActionResult> GetByEmployee(Int64 Id)
        {
            var entities = await _service.GetReportByEmployeeId(new GetByIdVM { Id=Id});
            return Ok(entities);
        }
        [HttpGet("GetByDepartment/{Id}")]
        public async Task<IActionResult> GetByDepartment(Int64 Id)
        {
            var entities = await _service.GetReportByDepartmentId(new GetByIdVM { Id=Id});
            return Ok(entities);
        }
        [HttpGet("GetByCompany/{Id}")]
        public async Task<IActionResult> GetReportByCompanyId(Int64 Id)
        {
            var entities = await _service.GetReportByCompanyId(new GetByIdVM { Id=Id});
            return Ok(entities);
        }

        
    }
}