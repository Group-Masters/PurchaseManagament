using PurchaseManagament.Persistence.Concrete.Audits;

namespace PurchaseManagament.Domain.Common
{
    public abstract class BaseEntity
    {
        public Int64 Id { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
