using PurchaseManagament.Domain.Common;
using PurchaseManagament.Domain.Enums;

namespace PurchaseManagament.Domain.Entities
{
    public class Offer : AuditableEntity
    {
        public Int64 CurrencyId { get; set; }
        public Int64 SupplierId { get; set; }
        public Int64? ApprovingEmployeeId { get; set; }
        public string Details { get; set; }

        public virtual Currency Currency { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual Employee ApprovingEmployee { get; set; }
        public virtual Status Status { get; set; }
        public virtual Invoice Invoice { get; set; }
        public virtual IEnumerable<MaterialOffer> MaterialOffers { get; set; }
    }
}
