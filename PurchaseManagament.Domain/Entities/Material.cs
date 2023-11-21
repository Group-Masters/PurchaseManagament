using PurchaseManagament.Domain.Common;

namespace PurchaseManagament.Domain.Entities
{
    public class Material : AuditableEntity
    {
        public long RequestId { get; set; }
        public string ProductId { get; set; }
        public string Details { get; set; }
        public double Quantity { get; set; }

        public virtual Request Request { get; set; }
        public virtual Product Product { get; set; }
        public virtual IEnumerable<MaterialOffer> MaterialOffers { get; set; }
    }
}
