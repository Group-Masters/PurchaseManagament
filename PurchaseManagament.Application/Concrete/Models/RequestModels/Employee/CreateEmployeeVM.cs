using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Application.Concrete.Models.RequestModels.Employee
{
    public class CreateEmployeeVM
    {
        public Int64? DepartmentId { get; set; }
        public Int64? CompanyId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdNumber { get; set; }
        public string BirthYear { get; set; }
        public int Gender { get; set; }
        public string Username { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        

    }
}
