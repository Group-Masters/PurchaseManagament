namespace PurchaseManagament.Application.Concrete.Models.Dtos
{
    public class CompanyStocksDto
    {
        public long Id { get; set; }
        public double Quantity { get; set; }
        public long CompanyId { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; } 
        public string MeasuringUnitName { get; set; }
    }
}
