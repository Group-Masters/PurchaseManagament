namespace PurchaseManagament.Application.Concrete.Models.Dtos
{
    public class MaterialOfferDto
    {
        public long Id { get; set; }
        public long OfferId { get; set; }
        public string SupplierName { get; set; }
        public long MaterialId { get; set; }
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
        public string MeasuringUnit { get; set; }
        public decimal OfferedPrice { get; set; }
        public string Currency {  get; set; }
    }
}
