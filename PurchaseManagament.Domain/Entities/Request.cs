using PurchaseManagament.Domain.Common;
using PurchaseManagament.Domain.Enums;

namespace PurchaseManagament.Domain.Entities
{
    public class Request:AuditableEntity
    {
        public long ProductId { get; set; }
  
        public long? ApprovingEmployeeId { get; set; }

        public long RequestEmployeeId { get; set; }
        public string Details { get; set; }
        public double Quantity { get; set; }
        public DateTime? ApprovedDate { get; set; }

        public virtual Product Product { get; set; }
        public virtual Employee ApprovedEmployee { get; set; } // Onaylayan 
        public virtual Employee RequestEmployee { get; set; } // Talep eden
        public virtual IEnumerable<Offer> Offers { get; set; }

        public virtual Status State { get; set; } // Durum



    }




}
