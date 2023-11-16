using PurchaseManagament.Domain.Common;

namespace PurchaseManagament.Domain.Entities
{
    // Para Birimi
    public class Currency:AuditableEntity
    {
        public string Name { get; set; }
        public virtual IEnumerable<Offer> Offers { get; set; }
    }
}
