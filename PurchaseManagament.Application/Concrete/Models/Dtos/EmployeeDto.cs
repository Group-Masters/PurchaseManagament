using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Application.Concrete.Models.Dtos
{
    public class EmployeeDto
    {
        public long Id { get; set; }
        public long CompanyDepartmentId { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string IdNumber { get; set; }
        public string BirthYear { get; set; }
        public bool? IsActive { get; set; }
    }
}
