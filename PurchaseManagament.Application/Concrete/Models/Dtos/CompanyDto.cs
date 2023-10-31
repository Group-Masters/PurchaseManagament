namespace PurchaseManagament.Application.Concrete.Models.Dtos
{
    public class CompanyDto
    {
        public string Name { get; set; }
        public string Adress { get; set; }

        public virtual IEnumerable<CompanyDepartmentDto> CompanyDepartments { get; set; } // Şirket ve Departman
        public virtual IEnumerable<CompanyStock> CompanyStocks { get; set; } // Şirket Stok
    }
}
