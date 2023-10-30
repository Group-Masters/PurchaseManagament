using PurchaseManagament.Domain.Common;

namespace PurchaseManagament.Domain.Entities
{
    public class Request:AuditableEntity
    {
        public long ProductId { get; set; }
        public long StatusId { get; set; }
        public long ApprovingEmployeeId { get; set; }
        public long RequestEmployeeId { get; set; }
        public string Details { get; set; }
        public double Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual Status Status { get; set; }
        public virtual Employee ApprovedEmployee { get; set; }
        public virtual Employee RequestEmployee { get; set; }
        public virtual IEnumerable<Offer> Offers { get; set; }
    }
}
