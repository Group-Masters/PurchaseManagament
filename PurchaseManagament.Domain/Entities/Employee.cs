using PurchaseManagament.Domain.Common;

namespace PurchaseManagament.Domain.Entities
{
    public class Employee : AuditableEntity
    {
        public long CompanyDepartmentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdNumber { get; set; }
       
        public string BirthYear { get; set; }
        public Gender Gender { get; set; }

        public virtual CompanyDepartment CompanyDepartment { get; set; }
        public virtual EmployeeDetail EmployeeDetail { get; set; }
        public virtual IEnumerable<EmployeeRole> EmployeeRoles { get; set; }
        public virtual IEnumerable<Offer> Offers { get; set; }
        public virtual IEnumerable<Request> EmployeeRequests { get; set; }
        public virtual IEnumerable<Material> ApprovedMaterials { get; set; }
        public virtual IEnumerable<StockOperations> StockOperations { get; set; }
    }
    public  enum Gender
    {
        Male = 0,
        Female=1,
    }
}
