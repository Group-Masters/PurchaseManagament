using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Application.Concrete.Models.Dtos
{
    public class CompanyDepartmentDto
    {
        public Int64 Id { get; set; }
        public Int64 CompanyId { get; set; }
        public Int64 DepartmentId { get; set; }
    }
}
