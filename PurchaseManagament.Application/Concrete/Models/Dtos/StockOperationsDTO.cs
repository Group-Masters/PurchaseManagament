namespace PurchaseManagament.Application.Concrete.Models.Dtos
{
    public class StockOperationsDto
    {
        public Int64 Id { get; set; }
        public long CompanyStockId { get; set; }
        public long CompanyDepartmentId { get; set; }
        public double Quantity { get; set; }
    }
}
