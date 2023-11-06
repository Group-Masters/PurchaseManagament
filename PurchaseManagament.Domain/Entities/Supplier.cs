using PurchaseManagament.Domain.Common;

namespace PurchaseManagament.Domain.Entities
{
    public class Supplier : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual IEnumerable<Offer> Offers { get; set; }
    }
}
