using PurchaseManagament.Application.Concrete.Models.Dtos.AuditHistory;
using PurchaseManagament.Application.Concrete.Models.RequestModels.AuditHistory;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.Application.Abstract.Service.AuditHistoryService
{
    public interface IAuditHistoryService
    {
        Task<Result<HashSet<AuditHistoryDto>>> GetAllAuditHistory();
        Task<Result<HashSet<AuditSmallDto>>> GetAuditsByEmployeeId(GetByIdVM getByIdVM);
        Task<Result<HashSet<AuditHistoryDto>>> GetAuditsByTable(GetAuditsByTableRM getAuditsByOperationRM);
        Task<Result<HashSet<AuditHistoryDto>>> GetAuditsSpecified(GetAuditsSpecifiedRM getAuditsSpecifiedRM);
        Task<Result<AuditHistoryDto>> GetAuditById(GetByIdAuditRM getByIdAuditRM);
    }
}
