namespace PurchaseManagament.Application.Concrete.Models.Dtos
{
    public class OfferDto
    {
        public long Id { get; set; }
        public Int64 CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public Int64 SupplierId { get; set; }
        public string SupplierName { get; set; }
        public Int64 RequestId { get; set; }
        public Int64 ApprovingEmployeeId { get; set; }
        public string ApprovingEmployeeName { get; set; }
        public string ApprovingEmployeeSurname { get; set; }
        public decimal OfferedPrice { get; set; }
        public string ProductName { get; set; }
        public double Quantity { get; set; }
        public string Details { get; set; }
    }
}
