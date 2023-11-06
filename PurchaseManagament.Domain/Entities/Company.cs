using PurchaseManagament.Domain.Common;

namespace PurchaseManagament.Domain.Entities
{
    // Şirket
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public string Adress { get; set; }

        public virtual IEnumerable<CompanyDepartment> CompanyDepartments { get; set; } // Şirket ve Departman
        public virtual IEnumerable<CompanyStock> CompanyStocks { get; set; } // Şirket Stok
    }
}
