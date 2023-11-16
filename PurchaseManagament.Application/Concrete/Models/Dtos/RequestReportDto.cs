using PurchaseManagament.Domain.Enums;

namespace PurchaseManagament.Application.Concrete.Models.Dtos
{
    public class RequestReportDto
    {
        public long Id { get; set; }
        public string CompanyName { get; set; }
        public string DepartmentName { get; set; }
        public string RequestEmployeeName { get; set; }
        public string RequestEmployeeSurname { get; set; }
        public DateTime? RequestDate { get; set; }

        public string ProductName { get; set; }
        public string MeasuringUnitName { get; set; }
        public double Quantity { get; set; }
        public string Details { get; set; }

        public Status Status { get; set; }
        public string? RequestApproveName { get; set; }
        public string? RequestApproveSurname { get; set; }
        public DateTime? RequestApproveDate { get; set; }

        public int? OfferCount { get; set; }
        public long ApprovedOfferId { get; set; }
        public DateTime? OfferCreateDate { get; set; }
        public string OfferApproveName { get; set; }
        public string OfferApproveSurname { get; set; }
        public DateTime? OfferApproveDate { get; set; }

        public string SupplierName { get; set; }
        public decimal OfferedPrice { get; set; }
        public string CurrencyName { get; set; }

        public Guid UUID { get; set; }
        public string RegisterName {  get; set; }
        public string RegisterSurname { get; set; }
        public DateTime? InvoiceCreateDate { get; set; }

        public long CompanyStockId { get; set; }
        public string StockName { get; set; }
        public string StockSurname { get; set; }
        public DateTime? StockAddedDate { get; set; }
    }
}
