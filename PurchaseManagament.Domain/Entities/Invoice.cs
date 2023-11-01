using PurchaseManagament.Domain.Common;

namespace PurchaseManagament.Domain.Entities
{
    // Fatura
    public class Invoice : AuditableEntity
    {
        public Int64 OfferId { get; set; }
        public Guid UUID { get; set; }
        public virtual Offer Offer { get; set; }
    }
}
