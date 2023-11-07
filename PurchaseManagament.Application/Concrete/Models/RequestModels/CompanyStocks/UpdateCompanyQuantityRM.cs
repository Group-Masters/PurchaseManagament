namespace PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyStocks
{
    public class UpdateCompanyQuantityRM
    {
        public Int64 Id { get; set; }
        public double Quantity { get; set; }
        public bool? ToplaCıkar { get; set; } // Topla => true / Cıkar => false  
        public long CompanyDepartmentId { get; set; }
    }
}
