using PurchaseManagament.Application.Concrete.Models.Dtos.AuditHistory;
using PurchaseManagament.Application.Concrete.Models.RequestModels.AuditHistory;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.Application.Abstract.Service.AuditHistoryService
{
    public interface IAuditHistoryService
    {
        Task<Result<HashSet<AuditHistoryDto>>> GetAllAuditHistory();
        Task<Result<HashSet<AuditSmallDto>>> GetAuditsByUserId(GetAuditsByUserIdRM getAuditsByUserIdRM);
        Task<Result<HashSet<AuditHistoryDto>>> GetAuditsByDisplayName(GetAuditsByDislpayNameRM getAuditsByDislpayNameRM);
        Task<Result<HashSet<AuditHistoryDto>>> GetAuditsSpecified(GetAuditsSpecifiedRM getAuditsSpecifiedRM);
        Task<Result<HashSet<AuditHistoryDto>>> GetAuditsByCompany(GetAuditsByCompanyId getAuditsByCompanyId);
        Task<Result<AuditHistoryDto>> GetAuditHistoryById(GetByIdAuditRM getByIdAuditRM);
    }
}
