using Microsoft.EntityFrameworkCore;
using PurchaseManagament.Domain.Abstract;
using PurchaseManagament.Domain.Common;
using PurchaseManagament.Domain.Concrete;
using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Persistence.Concrete.Mappings;
using PurchaseManagament.Utils;
using System.Reflection.Emit;

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
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<MaterialOffer> MaterialOffers { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<StockOperations> StockOperations { get; set; }
        public virtual DbSet<ImgProduct> ImgProducts { get; set; }

        private readonly ILoggedService _loggedUserService;

        public PurchaseManagamentContext(DbContextOptions<PurchaseManagamentContext> options, ILoggedService loggedService) : base(options)
        {
            //Silince Runtime'da hata veriliyor dendi, hata durumunda yorum satırından çıkarmayı dene
            //Database.EnsureCreated();
            _loggedUserService = loggedService;
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=PURCHASEMANAGAMENT_DB;Trusted_Connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Veritabanı İlkleme
            new DbInitializer(modelBuilder).Seed();
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
            modelBuilder.ApplyConfiguration(new MaterialMapping());
            modelBuilder.ApplyConfiguration(new MaterialOfferMapping());
            modelBuilder.ApplyConfiguration(new RoleMapping());
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new StockOperationMapping());
            modelBuilder.ApplyConfiguration(new SupplierMapping());
            modelBuilder.ApplyConfiguration(new ImgProductMapping());

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
            modelBuilder.Entity<Material>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<MaterialOffer>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<Role>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<Supplier>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<StockOperations>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<ImgProduct>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
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

        public class DbInitializer
        {
            private readonly ModelBuilder modelBuilder;

            public DbInitializer(ModelBuilder modelBuilder)
            {
                this.modelBuilder = modelBuilder;
            }

            //Migration ile birlikte çalışır
            public void Seed()
            {
                modelBuilder.Entity<Company>().HasData(
                       new Company() { Id = 1, Name = "Varsayılan Şirket", Address = "Varsayılan Adres" }
                );
                modelBuilder.Entity<Department>().HasData(
                       new Department { Id = 1, Name = "Varsayılan Departman" }
                );
                modelBuilder.Entity<CompanyDepartment>().HasData(
                       new CompanyDepartment { Id = 1, CompanyId = 1, DepartmentId = 1 }
                );
                //Admin kullanıcısının gerçek bilgileri burada verilmelidir.
                modelBuilder.Entity<Employee>().HasData(
                        new Employee { Id = 1, CompanyDepartmentId = 1, Name = "Varsayılan", Surname = "Çalışan", IdNumber = "12345678910", BirthYear = "1999", Gender = 0 }
                );
                modelBuilder.Entity<EmployeeDetail>().HasData(
                        new EmployeeDetail { Id = 1, Username = "Varsayılan", Address = "Varsayılan Adres", Phone = "12345678910", Email = "default@mail.com", Password = "kVU41twDyttUL/SM7IO0vQ==", EmployeeId = 1, EmailOk = true, ApprovedCode = "111111" }
                );
                //Değiştirilmemeli
                modelBuilder.Entity<Role>().HasData(
                       new Role { Id = 1, Name = "Admin" },
                       new Role { Id = 2, Name = "Satın Alma Sorumlusu" },
                       new Role { Id = 3, Name = "Onay" },
                       new Role { Id = 4, Name = "Talep" },
                       new Role { Id = 5, Name = "Birim Sorumlusu" },
                       new Role { Id = 6, Name = "Muhasebe" },
                       new Role { Id = 7, Name = "Genel Müdür" },
                       new Role { Id = 8, Name = "Y.K Başkanı" },
                       new Role { Id = 9, Name = "Stok Sorumlusu" },
                       new Role { Id = 10, Name = "Birim Müdürü" }
                );
                modelBuilder.Entity<EmployeeRole>().HasData(
                       new EmployeeRole { Id = 1, EmployeeId = 1, RoleId = 1 }
                );
                //Değiştirilmemeli
                modelBuilder.Entity<Supplier>().HasData(
                       new Supplier { Id = 1, Name = "Şirket Stok", Address = "Şirket Adres" }
                );

                //Ekstralar
                modelBuilder.Entity<MeasuringUnit>().HasData(
                       new MeasuringUnit { Id = 1, Name = "Adet", },
                       new MeasuringUnit { Id = 2, Name = "Kilogram", },
                       new MeasuringUnit { Id = 3, Name = "Metre", },
                       new MeasuringUnit { Id = 4, Name = "Metrekare", },
                       new MeasuringUnit { Id = 5, Name = "Metre Küp", },
                       new MeasuringUnit { Id = 6, Name = "Litre", }
                );
                //Referans: https://www.tcmb.gov.tr/kurlar/today.xml
                modelBuilder.Entity<Currency>().HasData(
                       new Currency { Id = 1, Name = "TRY" },
                       new Currency { Id = 2, Name = "USD" },
                       new Currency { Id = 3, Name = "AUD" },
                       new Currency { Id = 4, Name = "DKK" },
                       new Currency { Id = 5, Name = "EUR" },
                       new Currency { Id = 6, Name = "GBP" },
                       new Currency { Id = 7, Name = "CHF" },
                       new Currency { Id = 8, Name = "SEK" },
                       new Currency { Id = 9, Name = "CAD" },
                       new Currency { Id = 10, Name = "KWD" },
                       new Currency { Id = 11, Name = "NOK" },
                       new Currency { Id = 12, Name = "SAR" },
                       new Currency { Id = 13, Name = "JPY" }
                );
            }
        }
    }
}
