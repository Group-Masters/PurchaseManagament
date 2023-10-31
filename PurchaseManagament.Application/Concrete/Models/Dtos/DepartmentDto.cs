using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Application.Concrete.Models.Dtos
{
    public class DepartmentDto
    {
        public string Name { get; set; }
        public virtual IEnumerable<CompanyDepartmentDto> CompanyDepartments { get; set; } // Şirket ve Departman
    }
}
