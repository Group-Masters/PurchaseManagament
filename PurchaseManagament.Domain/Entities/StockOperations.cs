using PurchaseManagament.Domain.Common;

namespace PurchaseManagament.Domain.Entities
{
    public class StockOperations:AuditableEntity
    {
        public long CompanyStockId { get; set; }
        public long CompanyDepartmentId {  get; set; }
        public double Quantity { get; set; }
        public virtual CompanyStock CompanyStock { get; set; }
        public virtual CompanyDepartment CompanyDepartment { get; set; }
    }
}
