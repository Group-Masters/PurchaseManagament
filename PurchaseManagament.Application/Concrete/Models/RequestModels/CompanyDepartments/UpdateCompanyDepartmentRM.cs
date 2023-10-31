

using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyDepartments
{
    public class UpdateCompanyDepartmentRM
    {
        public long? CompanyId { get; set; }
        public long? DepartmentId { get; set; }
        public virtual CompanyDto? Company { get; set; }
        public virtual DepartmentDto? De5partment { get; set; }
        public IEnumerable<EmployeeDto>? Employes { get; set; }
    }
}
