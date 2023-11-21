namespace PurchaseManagament.Application.Concrete.Models.Dtos
{
    public class MaterialOfferDto
    {
        public long Id { get; set; }
        public long OfferId { get; set; }
        public long MaterialId { get; set; }
        public double OfferedPrice { get; set; }
    }
}
