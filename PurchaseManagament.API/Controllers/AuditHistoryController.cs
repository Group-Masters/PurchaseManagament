using Microsoft.AspNetCore.Mvc;
using PurchaseManagament.Application.Abstract.Service.AuditHistoryService;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.Dtos.AuditHistory;
using PurchaseManagament.Application.Concrete.Models.RequestModels.AuditHistory;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Companies;
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
            var result = await _auditHistoryService.GetAuditById(new GetByIdAuditRM { Id = id });
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAuditHistory()
        {
            var entities = await _auditHistoryService.GetAllAuditHistory();
            return Ok(entities);
        }
    }
}
