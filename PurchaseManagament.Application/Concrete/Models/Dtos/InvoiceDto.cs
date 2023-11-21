namespace PurchaseManagament.Application.Concrete.Models.Dtos
{
    public class InvoiceDto
    {
        public Int64 Id { get; set; }
        public long OfferId { get; set; }
        public Guid UUID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string SupplierName { get; set; }
        public string SupplierAddress { get; set; }
        public decimal TotalPrice { get; set; }
        public string Currency {  get; set; }
        public DateTime CreatedDate { get; set; }

        public HashSet<MaterialDto> MaterialDtos { get; set; }

    }
}
