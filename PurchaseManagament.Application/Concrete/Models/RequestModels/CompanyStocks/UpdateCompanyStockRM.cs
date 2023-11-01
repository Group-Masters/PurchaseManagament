namespace PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyStocks
{
    public class UpdateCompanyStockRM
    {
        public long Id { get; set; }
        public double Quantity { get; set; }
        public long CompanyId { get; set; }
        public long ProductId { get; set; }
    }
}
