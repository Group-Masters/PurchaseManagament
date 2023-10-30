using PurchaseManagament.Domain.Common;

namespace PurchaseManagament.Domain.Entities
{
    public class Department:AuditableEntity
    {
        public string Name { get; set; }
        public virtual IEnumerable<CompanyDepartment> CompanyDepartments { get; set; }
    }
}
