using PurchaseManagament.Domain.Common;

namespace PurchaseManagament.Domain.Entities
{
    public class Supplier:AuditableEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual IEnumerable<Offer> Offers { get; set; }
    }
}
