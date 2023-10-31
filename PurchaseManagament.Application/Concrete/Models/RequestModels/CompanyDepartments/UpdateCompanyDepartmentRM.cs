

using PurchaseManagament.Application.Concrete.Models.Dtos;

namespace PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyDepartments
{
    public class UpdateCompanyDepartmentRM
    {
        public Int64? CompanyId { get; set; }
        public Int64? DepartmentId { get; set; }
    }
}
