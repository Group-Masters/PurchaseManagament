using PurchaseManagament.Domain.Common;

namespace PurchaseManagament.Domain.Entities
{
    // Şirket ve Departman Ara Tablo
    public class CompanyDepartment : BaseEntity
    {
        // Nav Prop
        public long CompanyId { get; set; }
        public long DepartmentId { get; set; }
        public virtual Company Company { get; set; }
        public virtual Department Department { get; set; }
        public virtual IEnumerable<Employee> Employees { get; set; }
        //public virtual IEnumerable<StockOperations> StockOperations { get; set; }
    }
}
