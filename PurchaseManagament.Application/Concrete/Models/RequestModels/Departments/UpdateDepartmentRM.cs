using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Application.Concrete.Models.RequestModels.Departments
{
    public class UpdateDepartmentRM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<CompanyDepartment>? CompanyDepartments { get; set; } // Şirket ve Departman
    }
}
