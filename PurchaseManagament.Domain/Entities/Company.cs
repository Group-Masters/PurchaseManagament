using PurchaseManagament.Domain.Common;

namespace PurchaseManagament.Domain.Entities
{
    public class Company:AuditableEntity
    {
        public string  Name { get; set; }
        public virtual IEnumerable<CompanyDepartment> CompanyDepartments { get; set; }
        public virtual IEnumerable<CompanyStock> CompanyStocks { get; set; }

    }
}
