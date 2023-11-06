namespace PurchaseManagament.Application.Concrete.Models.RequestModels.Offers
{
    public class CreateOfferRM
    {
        public Int64 CurrencyId { get; set; }
        public Int64 SupplierId { get; set; }
        public Int64 RequestId { get; set; }
        //public Int64 ApprovingEmployeeId { get; set; }
        public decimal OfferedPrice { get; set; }
        public string? Details { get; set; }
    }
}
