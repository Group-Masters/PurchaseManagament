using Microsoft.EntityFrameworkCore;
using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Persistence.Concrete.Context
{
    public class PurchaseManagamentContext : DbContext
    {
        //Tables => Db deki tablo şemaları
        //public DbSet<> Table { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<CompanyDepartment> CompanyDepartments { get; set; }
        public virtual DbSet<CompanyStock> CompanyStocks { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeDetail> EmployeeDetails { get; set; }
        public virtual DbSet<EmployeeRole> EmployeesRoles { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<MeasuringUnit> MeasuringUnits { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<StockOperations> StockOperations { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=PURCHASEMANAGAMENT_DB;Trusted_Connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Example
            //modelBuilder.ApplyConfiguration(new Employee());
        }
    }
}
