using EFCore.Audit;

namespace PurchaseManagament.Domain.Common
{
    [Auditable]
    public abstract class BaseEntity
    {
        public Int64 Id { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
