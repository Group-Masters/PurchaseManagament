using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Application.Concrete.Models.Dtos
{
    public class CompanyDepartmentDto
    {
        public long CompanyId { get; set; }
        public long DepartmentId { get; set; }
        public virtual Company Company { get; set; }
        public virtual Department Department { get; set; }
        public IEnumerable<Employee> Employes { get; set; }
    }
}
