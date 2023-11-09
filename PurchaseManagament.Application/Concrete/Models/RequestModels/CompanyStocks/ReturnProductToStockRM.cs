namespace PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyStocks
{
    public class ReturnProductToStockRM
    {
        public long Id { get; set; }
        public long CompanyStockId { get; set; }
        public long ReceivingEmployeeId { get; set; }
        public double Quantity { get; set; }
    }
}
