using PurchaseManagament.Domain.Common;
using PurchaseManagament.Domain.Enums;

namespace PurchaseManagament.Domain.Entities
{
    public class Material : AuditableEntity
    {
        public long RequestId { get; set; }
        public long ProductId { get; set; }
        public string Details { get; set; }
        public double Quantity { get; set; }

        public virtual Status State { get; set; } // Durum
        public long? ApprovingEmployeeId { get; set; }
        public DateTime? ApprovedDate { get; set; }


        public virtual Employee ApprovedEmployee { get; set; } // Onaylayan 
        public virtual Request Request { get; set; }
        public virtual Product Product { get; set; }
        public virtual IEnumerable<MaterialOffer> MaterialOffers { get; set; }
    }
}
