using PurchaseManagament.Domain.Common;

namespace PurchaseManagament.Domain.Entities
{
    public class Role:AuditableEntity
    {
        public string Name { get; set; }
        public virtual IEnumerable<EmployeeRole> EmployeeRoles { get; set; }
    }
}
