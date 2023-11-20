using PurchaseManagament.Domain.Enums;

namespace PurchaseManagament.Application.Concrete.Models.Dtos
{
    public class RequestReportDto
    {
        public long Id { get; set; }
        public string CompanyName { get; set; }
        public string DepartmentName { get; set; }
        public string RequestEmployee { get; set; }
        public string RequestDate { get; set; }

        public string Product { get; set; }
        public string Quantity { get; set; }
        public string? RequestDetails { get; set; }

        public Status Status { get; set; }
        public string? RequestApproveBy { get; set; }
        public string? RequestApproveDate { get; set; }
        public string Prices { get; set; }

        public string? OfferCount { get; set; }
        public string? InvoiceCreateDate { get; set; }
        public string? UUID { get; set; }
        public List<OfferReportDto>? Offers { get; set; }
        
        
       
    }
}
