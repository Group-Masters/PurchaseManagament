namespace PurchaseManagament.Application.Concrete.Models.Dtos
{
    public class CompanyDepartmentDto
    {
        public Int64 Id { get; set; }
        public Int64 CompanyId { get; set; }
        public string CompanyName { get; set; }
        public Int64 DepartmentId { get; set; }
        public string DepartmentName { get; set;}
    }
}
