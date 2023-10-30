using PurchaseManagament.Domain.Common;

namespace PurchaseManagament.Domain.Entities
{
    public class EmployeeDetail:AuditableEntity
    {
        public long EmployeeId { get; set; }
        public bool? EmailOk { get; set; }
        public string? ApprovedCode { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
