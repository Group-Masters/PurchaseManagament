using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Application.Concrete.Models.RequestModels.Employee
{
    public class CreateEmployeeVM
    {
        public Int64 DepartmantId { get; set; }
        public Int64 CompanyId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdNumber { get; set; }
        public string BirthYear { get; set; }
        public Gender Gender { get; set; }
        public string Username { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
