namespace PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyStocks
{
    public class CreateCompanyStockRM
    {
        public double Quantity { get; set; }
        public long CompanyId { get; set; }
        public long ProductId { get; set; }
    }
}
