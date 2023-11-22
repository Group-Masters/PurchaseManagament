namespace PurchaseManagament.Application.Concrete.Models.Dtos
{
    public class MaterialOfferDto
    {
        public long Id { get; set; }
        public long OfferId { get; set; }
        public string SupplierName { get; set; }
        public long MaterialId { get; set; }
        public string ProductName { get; set; }
        public double Quantity { get; set; }
        public string MeasuringUnit { get; set; }
        public double OfferedPrice { get; set; }
        public string Currency {  get; set; }
    }
}
