namespace PurchaseManagament.Application.Concrete.Models.Dtos
{
    public class UpdateEmployeeVM
    {
        public long  EmployeeId { get; set; }
        public string Username { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool? IsActive { get; set; }
    }
}
