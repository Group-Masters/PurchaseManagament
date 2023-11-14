﻿using Microsoft.AspNetCore.Mvc;
using PurchaseManagament.Application.Abstract.Service.AuditHistoryService;
using PurchaseManagament.Application.Concrete.Models.Dtos.AuditHistory;
using PurchaseManagament.Application.Concrete.Models.RequestModels.AuditHistory;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.API.Controllers
{
    [Route("AuditHistory")]
    public class AuditHistoryController : ControllerBase
    {
        private readonly IAuditHistoryService _auditHistoryService;

        public AuditHistoryController(IAuditHistoryService auditHistoryService)
        {
            _auditHistoryService = auditHistoryService;
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<Result<AuditHistoryDto>>> GetAuditHistoryById(Guid id)
        {
            var result = await _auditHistoryService.GetAuditHistoryById(new GetByIdAuditRM { Id = id });
            return Ok(result);
        }

        [HttpGet("GetByEmployee/{id}")]
        public async Task<ActionResult<Result<HashSet<AuditHistoryDto>>>> GetAuditsByEmployeeId(long id)
        {
            var entities = await _auditHistoryService.GetAuditsByUserId(new GetAuditsByUserIdRM { UserId = id});
            return Ok(entities);
        }

        [HttpGet("GetByCompany/{id}")]
        public async Task<ActionResult<Result<HashSet<AuditHistoryDto>>>> GetAuditsByCompany(long id)
        {
            var entities = await _auditHistoryService.GetAuditsByCompany(new GetAuditsByCompanyIdRM { CompanyId = id});
            return Ok(entities);
        }

        [HttpGet("GetByDisplayName")]
        public async Task<ActionResult<Result<HashSet<AuditHistoryDto>>>> GetAuditsByDisplayName(string metaDisplayName )
        {
            var entities = await _auditHistoryService.GetAuditsByDisplayName(new GetAuditsByDislpayNameRM { MetaDisplayName = metaDisplayName });
            return Ok(entities);
        }

        [HttpGet("GetByCompanyDisplay/{id}")]
        public async Task<ActionResult<Result<HashSet<AuditHistoryDto>>>> GetAuditsByCompanyDisplay(long id, string metaDisplayName )
        {
            var entities = await _auditHistoryService.GetAuditsByCompanyDisplay(new GetAuditsByCompanyDisplayRM { CompanyId = id, MetaDisplayName = metaDisplayName });
            return Ok(entities);
        }

        [HttpGet("GetSpecified")]
        public async Task<ActionResult<Result<HashSet<AuditHistoryDto>>>> GetAuditsSpecified(Int64 Id, string metaDisplayName)
        {
            var entities = await _auditHistoryService.GetAuditsSpecified(new GetAuditsSpecifiedRM { ReadablePrimaryKey = $"Id={Id}", MetaDisplayName = metaDisplayName});
            return Ok(entities);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<Result<HashSet<AuditHistoryDto>>>> GetAllAuditHistory()
        {
            var entities = await _auditHistoryService.GetAllAuditHistory();
            return Ok(entities);
        }
    }
}