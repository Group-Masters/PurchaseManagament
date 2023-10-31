using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Application.Concrete.Models.RequestModels.Departments
{
    public class UpdateDepartmentRM
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
    }
}
