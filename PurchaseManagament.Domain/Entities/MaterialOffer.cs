using PurchaseManagament.Domain.Common;

namespace PurchaseManagament.Domain.Entities
{
    public class MaterialOffer : AuditableEntity
    {
        public long OfferId { get; set; }
        public long MaterialId { get; set; }
        public double OfferedPrice { get; set; }

        public virtual Material Material { get; set; }
        public virtual Offer Offer { get; set; }
    }
}
