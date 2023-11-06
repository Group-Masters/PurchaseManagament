using EFCore.Audit;

namespace PurchaseManagament.Domain.Common
{
    [Auditable]
    public abstract class BaseEntity
    {
        public Int64 Id { get; set; }
        [NotAuditable]
        public bool? IsActive { get; set; }
        [NotAuditable]
        public bool? IsDeleted { get; set; }

    }
}
