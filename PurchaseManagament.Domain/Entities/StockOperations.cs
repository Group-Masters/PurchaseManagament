using PurchaseManagament.Domain.Common;

namespace PurchaseManagament.Domain.Entities
{
    public class StockOperations:AuditableEntity
    {
        public StockOperations()
        {
            Notification = Quantity.ToString() + " Adet Stoktan tedarik edildi";
        }
        public long CompanyStockId { get; set; }
        public long ReceiverEmployeeId { get; set; }
        public long ProductId { get; set; }
        public double Quantity { get; set; }
        public string Notification { get; set; }
        public virtual CompanyStock CompanyStock { get; set; }
        public virtual Product Product { get; set; }

        public virtual Employee ReceiverEmployee { get; set; }

    }

}
