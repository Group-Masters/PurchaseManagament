using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Domain.Entities
{
    public class Employee
    {
        public long CompanyDepartmentId { get; set; }
        public long EmployeeDetailId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string BirthYear { get; set; }

        public virtual  CompanyDepartment CompanyDepartment { get; set; }
        public EmployeeDetail EmployeeDetail { get; set; }
        public IEnumerable<EmployeeRole> EmployeeRoles { get; set; }
        public IEnumerable<Company> Companys { get; set; }
        public IEnumerable<CompanyDepartment> CompanyDepartments { get; set; }
        public IEnumerable<CompanyStock> CompanyStocks { get; set; }
        public IEnumerable<Currency> Currencies { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Invoice> Invoices { get; set; }
        public IEnumerable<MeasuringUnit> MeasuringUnits { get; set; }
        public IEnumerable<Offer> Offers { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Request> Requests { get; set; }
        public IEnumerable<Role> Roles { get; set; }
        public IEnumerable<Status> Statuses { get; set; }
        public IEnumerable<StockOperations> StockOperations { get; set; }
        public IEnumerable<Supplier> Suppliers { get; set; }
      


















        
    }
}
