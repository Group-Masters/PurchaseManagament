namespace PurchaseManagament.Application.Concrete.Models.RequestModels.Invoices
{
    public class UpdateInvoiceRM
    {
        public long Id { get; set; }
        public Int64 OfferId { get; set; }
        public Guid UUID { get; set; }
    }
}
