using PurchaseManagament.Domain.Enums;

namespace PurchaseManagament.Application.Concrete.Models.RequestModels.Invoices
{
    public class UpdateInvoiceStatusRM
    {
        public Int64 Id { get; set; }
        public Status Status { get; set; }
    }
}
