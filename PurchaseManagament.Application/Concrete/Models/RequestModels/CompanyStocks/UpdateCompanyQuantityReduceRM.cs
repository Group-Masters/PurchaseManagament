namespace PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyStocks
{
    public class UpdateCompanyQuantityReduceRM
    {
        public Int64 Id { get; set; }
        public long ReceivingEmployeeId { get; set; }
        public double Quantity { get; set; }
    }
}
