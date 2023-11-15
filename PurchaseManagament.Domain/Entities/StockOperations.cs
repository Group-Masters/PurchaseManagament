using PurchaseManagament.Domain.Common;
using PurchaseManagament.Persistence.Concrete.Audits;

namespace PurchaseManagament.Domain.Entities
{
    [Auditable]
    public class StockOperations:AuditableEntity
    {
        public long CompanyStockId { get; set; }
        public long ReceivingEmployeeId {  get; set; }
        public double Quantity { get; set; }
        public virtual CompanyStock CompanyStock { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
