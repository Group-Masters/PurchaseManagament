using PurchaseManagament.Domain.Common;

namespace PurchaseManagament.Domain.Entities
{
    public class CompanyStock:AuditableEntity
    {
        public long CompanyId { get; set; }
        public long ProductId { get; set; }
        public double Quantity { get; set; }

        public virtual Company Company { get; set; }
        public virtual Product Product { get; set; }
        public virtual IEnumerable<StockOperations> StockOperations { get; set; }

    }
}
