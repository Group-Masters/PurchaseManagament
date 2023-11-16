using PurchaseManagament.Domain.Common;

namespace PurchaseManagament.Domain.Entities
{
    public class StockOperations:AuditableEntity
    {
        public Int64 CompanyStockId { get; set; }
        public Int64 ReceivingEmployeeId {  get; set; }
        public double Quantity { get; set; }
        public virtual CompanyStock CompanyStock { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
