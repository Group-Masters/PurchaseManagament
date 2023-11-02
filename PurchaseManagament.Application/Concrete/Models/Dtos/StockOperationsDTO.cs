namespace PurchaseManagament.Application.Concrete.Models.Dtos
{
    public class StockOperationsDto
    {
        public long CompanyStockId { get; set; }
        public long ReceiverEmployeeId { get; set; }
        public long ProductId { get; set; }
        public double Quantity { get; set; }
        public string? Notification { get; set; }

    }
}
