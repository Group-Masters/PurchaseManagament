using PurchaseManagament.Domain.Enums;

namespace PurchaseManagament.Application.Concrete.Models.Dtos
{
    public class OfferDto
    {
        public long Id { get; set; }
        public Int64 CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string SupplierName { get; set; }
        public string SupplierAddress { get; set; }
        public Int64 SupplierId { get; set; }
        public Status Status{ get; set; }
        public bool AboveThreshold { get; set; }
        public Int64 ApprovingEmployeeId { get; set; }
        public string ApprovingEmployeeName { get; set; }
        public string ApprovingEmployeeSurname { get; set; }

        public string Details { get; set; }
    }
}
