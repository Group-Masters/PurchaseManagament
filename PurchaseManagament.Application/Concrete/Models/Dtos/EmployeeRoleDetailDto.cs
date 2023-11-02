namespace PurchaseManagament.Application.Concrete.Models.Dtos
{
    public class EmployeeRoleDetailDto
    {
        public Int64 Id { get; set; }
        public Int64 EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public string EmployeeEmail { get; set; }
        public Int64 RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
