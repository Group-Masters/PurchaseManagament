using Microsoft.EntityFrameworkCore;
using PurchaseManagament.Domain.Abstract;
using PurchaseManagament.Domain.Common;
using PurchaseManagament.Domain.Concrete;
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

        private readonly ILoggedService _loggedUserService;

        public PurchaseManagamentContext(DbContextOptions<PurchaseManagamentContext> options, ILoggedService loggedService) : base(options)
        {
            Database.EnsureCreated();
            _loggedUserService = loggedService;
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

            //Aşağıdaki entity türleri için isDeleted bilgisi false olanların otomatik olarak filtrelenmesi sağlanır.
            modelBuilder.Entity<Company>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<CompanyDepartment>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<CompanyStock>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<Currency>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<Department>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<Employee>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<EmployeeDetail>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<EmployeeRole>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<Product>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<Invoice>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<MeasuringUnit>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<Offer>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<Request>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<Role>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<Supplier>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<StockOperations>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            //Herhangi bir kayıt işleminde yapılan işlem ekleme ise CreateDate ve CreatedBy bilgileri otomatik olarak set edilir.
            //Herhangi bir kayıt işleminde yapılan işlem güncelleme ise ModifiedDate ve ModifiedBy bilgileri otomatik olarak set edilir.

            var entries = ChangeTracker.Entries<BaseEntity>().ToList();

            foreach (var entry in entries)
            {
                //if (entry.State == EntityState.Deleted)
                //{
                //    entry.Entity.IsDeleted = true;
                //    entry.State = EntityState.Modified;
                //}

                if (entry.Entity is AuditableEntity auditableEntity)
                {
                    switch (entry.State)
                    {
                        //update
                        case EntityState.Modified:
                            auditableEntity.ModifiedDate = DateTime.Now;
                            auditableEntity.ModifiedBy = _loggedUserService.Username ?? "admin";
                            auditableEntity.ModifiedIP = _loggedUserService.Ip ?? "admin";
                            break;
                            
                        //insert
                        case EntityState.Added:
                            auditableEntity.CreatedDate = DateTime.Now;
                            auditableEntity.CreatedBy = _loggedUserService.UserId.ToString() ?? "admin";
                            auditableEntity.CreatedIP = _loggedUserService.Ip ?? "admin";
                            break;
                        //delete
                        //case EntityState.Deleted:
                        //    auditableEntity.ModifiedDate = DateTime.Now;
                        //    auditableEntity.ModifiedBy = _loggedUserService.Username.ToString() ?? "admin";
                        //    auditableEntity.ModifiedIP = _loggedUserService.Ip ?? "admin";
                        //    break;
                        default:
                            break;
                    }
                }

            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
