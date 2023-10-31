using Microsoft.EntityFrameworkCore;
using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Persistence.Concrete.Mappings;

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
       
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<StockOperations> StockOperations { get; set; }

        public PurchaseManagamentContext(DbContextOptions<PurchaseManagamentContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=PURCHASEMANAGAMENT_DB;Trusted_Connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyDepartmentMapping());
            modelBuilder.ApplyConfiguration(new CompanyMapping());
            modelBuilder.ApplyConfiguration(new CompanyStockMapping());
            modelBuilder.ApplyConfiguration(new CurrencyMapping());
            modelBuilder.ApplyConfiguration(new DepartmentMapping());
            modelBuilder.ApplyConfiguration(new EmployeeDetailMapping());
            modelBuilder.ApplyConfiguration(new EmployeeRoleMapping());
            modelBuilder.ApplyConfiguration(new EmployeeMapping());
            modelBuilder.ApplyConfiguration(new InvoiceMapping());
            modelBuilder.ApplyConfiguration(new MeasuringUnitMapping());
            modelBuilder.ApplyConfiguration(new OfferMapping());
            modelBuilder.ApplyConfiguration(new RequestMapping());
            modelBuilder.ApplyConfiguration(new RoleMapping());
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new StockOperationMapping());
            modelBuilder.ApplyConfiguration(new SupplierMapping());
        }
    }
}
