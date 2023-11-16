namespace PurchaseManagament.Application.Concrete.Models.Dtos
{
    public class InvoiceDto
    {
        public Int64 Id { get; set; }
        public Guid UUID { get; set; }
        public Int64 OfferId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string SupplierName { get; set; }
        public string SupplierAddress { get; set; }
        public string ProductName { get; set; }
        public double Quantity { get; set; }
        public string MeasuringUnit { get; set; }
        public decimal OfferedPrice { get; set; }
        public string Currency {  get; set; }
        public long RequestingEmployeeId { get; set; }
        public string RequestingEmployeeName { get; set; }
        public string RequestingEmployeeSurname { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime RequestCreatedDate { get; set; }
        public string ImageSrc { get; set; }
    }
}
