using PurchaseManagament.Domain.Common;
using PurchaseManagament.Persistence.Concrete.Audits;

namespace PurchaseManagament.Domain.Entities
{
    [Auditable]
    public class CompanyStock : BaseEntity
    {
        public double Quantity { get; set; }
        public long CompanyId { get; set; }
        public long ProductId { get; set; }

        // Nav Prop
        public virtual Company Company { get; set; }
        public virtual Product Product { get; set; }
        public virtual IEnumerable<StockOperations> StockOperations { get; set; }
    }
}
