using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyDepartments
{
    public class UpdateCompanyDepartmentRM
    {
        public long? CompanyId { get; set; }
        public long? DepartmentId { get; set; }
        public virtual Company? Company { get; set; }
        public virtual Department? De5partment { get; set; }
        public IEnumerable<Employee>? Employes { get; set; }
    }
}
