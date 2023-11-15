using PurchaseManagament.Domain.Common;
using PurchaseManagament.Domain.Enums;
using PurchaseManagament.Persistence.Concrete.Audits;

namespace PurchaseManagament.Domain.Entities
{
    // Fatura
    [Auditable]
    public class Invoice : AuditableEntity
    {
        public Int64 OfferId { get; set; }
        public Guid UUID { get; set; }
        public Status Status { get; set; }
        public virtual Offer Offer { get; set; }
    }
}
