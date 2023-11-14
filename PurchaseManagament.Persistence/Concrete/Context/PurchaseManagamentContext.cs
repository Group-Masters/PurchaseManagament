using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PurchaseManagament.Domain.Abstract;
using PurchaseManagament.Domain.Common;
using PurchaseManagament.Domain.Concrete.Audits;
using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Domain.Entities.Audits;
using PurchaseManagament.Persistence.Concrete.Audits;
using PurchaseManagament.Persistence.Concrete.Mappings;
using PurchaseManagament.Persistence.Concrete.Mappings.Audits;
using PurchaseManagament.Utils;

namespace PurchaseManagament.Persistence.Concrete.Context
{
    public class PurchaseManagamentContext : DbContext
    {
        //Tables => Db deki tablo şemaları
        //public DbSet<> Table { get; set; }

        public virtual DbSet<Audit> Audits { get; set; }
        public virtual DbSet<AuditMetaData> AuditMetaData { get; set; }
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
        public virtual DbSet<ImgProduct> ImgProducts { get; set; }

        private readonly ILoggedService _loggedUserService;

        public PurchaseManagamentContext(DbContextOptions<PurchaseManagamentContext> options, ILoggedService loggedService) : base(options)
        {
            _loggedUserService = loggedService;
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=PURCHASEMANAGAMENT_DB;Trusted_Connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            //Veritabanı ilkleme
            new DbInitializer(modelBuilder).Seed();
            modelBuilder.ApplyConfiguration(new AuditMapping());
            modelBuilder.ApplyConfiguration(new AuditMetaDataMapping());
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
            modelBuilder.ApplyConfiguration(new ImgProductMapping());

            //Aşağıdaki entity türleri için isDeleted bilgisi false olanların otomatik olarak filtrelenmesi sağlanır.
            modelBuilder.Entity<Company>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<CompanyDepartment>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<CompanyStock>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<Currency>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<Department>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<EmployeeRole>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<Product>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<Invoice>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<MeasuringUnit>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<Offer>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<Request>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<Role>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<Supplier>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<StockOperations>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<ImgProduct>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            IEnumerable<AuditEntry> entityAudits = OnBeforeSaveChanges();
            int result = base.SaveChanges(acceptAllChangesOnSuccess);
            OnAfterSaveChanges(entityAudits);

            return result;
        }


        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            //Herhangi bir kayıt işleminde yapılan işlem ekleme ise CreateDate ve CreatedBy bilgileri otomatik olarak set edilir.

            var entries = ChangeTracker.Entries<BaseEntity>().ToList();
            IEnumerable<AuditEntry> entityAudits = OnBeforeSaveChanges();

            foreach (var entry in entries)
            {
                if (entry.Entity is AuditableEntity auditableEntity)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditableEntity.CreatedDate = DateTime.Now;
                            auditableEntity.CreatedBy = _loggedUserService.UserId.ToString() ?? "admin";
                            break;
                        default:
                            break;
                    }
                }
            }

            int result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            await OnAfterSaveChangesAsync(entityAudits);

            return result;
        }

        private IEnumerable<AuditEntry> OnBeforeSaveChanges()
        {
            ChangeTracker.DetectChanges();
            List<AuditEntry> auditEntries = new List<AuditEntry>();
            foreach (EntityEntry entry in ChangeTracker.Entries())
            {
                if (!entry.ShouldBeAudited())
                {
                    continue;
                }

                auditEntries.Add(new AuditEntry(entry, _loggedUserService));
            }

            BeginTrackingAuditEntries(auditEntries.Where(_ => !_.HasTemporaryProperties));

            // keep a list of entries where the value of some properties are unknown at this step
            return auditEntries.Where(_ => _.HasTemporaryProperties);
        }

        private void OnAfterSaveChanges(IEnumerable<AuditEntry> auditEntries)
        {
            if (auditEntries == null || auditEntries.Count() == 0)
                return;

            BeginTrackingAuditEntries(auditEntries);

            base.SaveChanges();
        }

        private async Task OnAfterSaveChangesAsync(IEnumerable<AuditEntry> auditEntries)
        {
            if (auditEntries == null || auditEntries.Count() == 0)
                return;

            await BeginTrackingAuditEntriesAsync(auditEntries);

            await base.SaveChangesAsync();
        }

        private void BeginTrackingAuditEntries(IEnumerable<AuditEntry> auditEntries)
        {
            foreach (var auditEntry in auditEntries)
            {
                auditEntry.Update();
                AuditMetaData auditMetaData = auditEntry.ToAuditMetaData();
                AuditMetaData existedAuditMetaDataEntity = AuditMetaData.FirstOrDefault(x => x.HashPrimaryKey == auditMetaData.HashPrimaryKey && x.DisplayName == auditMetaData.DisplayName);
                if (existedAuditMetaDataEntity == default)
                {
                    Add(auditEntry.ToAudit(auditMetaData));
                }
                else
                {
                    Add(auditEntry.ToAudit(existedAuditMetaDataEntity));
                }
            }
        }

        private async Task BeginTrackingAuditEntriesAsync(IEnumerable<AuditEntry> auditEntries)
        {
            foreach (var auditEntry in auditEntries)
            {
                auditEntry.Update();
                AuditMetaData auditMetaData = auditEntry.ToAuditMetaData();
                AuditMetaData existedAuditMetaData = await AuditMetaData.FirstOrDefaultAsync(x => x.HashPrimaryKey == auditMetaData.HashPrimaryKey && x.DisplayName == auditMetaData.DisplayName);
                if (existedAuditMetaData == default)
                {
                    await AddAsync(auditEntry.ToAudit(auditMetaData));
                }
                else
                {
                    await AddAsync(auditEntry.ToAudit(existedAuditMetaData));
                }
            }
        }

        public class DbInitializer
        {
            private readonly ModelBuilder modelBuilder;

            public DbInitializer(ModelBuilder modelBuilder)
            {
                this.modelBuilder = modelBuilder;
            }

            public void Seed()
            {
                modelBuilder.Entity<Company>().HasData(
                       new Company() { Id = 1, Name = "Default Company", Address = "Default Address" }
                );
                modelBuilder.Entity<Department>().HasData(
                       new Department { Id = 1, Name = "Default Department" }
                );
                modelBuilder.Entity<CompanyDepartment>().HasData(
                       new CompanyDepartment { Id = 1, CompanyId = 1, DepartmentId = 1 }
                );
                //Admin kullanıcısının bilgileri burada verilebilir.
                modelBuilder.Entity<Employee>().HasData(
                        new Employee { Id = 1, CompanyDepartmentId = 1, Name = "Default", Surname = "Employee", IdNumber = "12345678910", BirthYear = "1999", Gender = 0 }
                );
                modelBuilder.Entity<EmployeeDetail>().HasData(
                        new EmployeeDetail {Id = 1, Username = "Default", Address = "Address", Phone = "12345678910", Email = "default@mail.com", Password = CipherUtils.EncryptString("b14ca5898a4e4133bbce2ea2315a1916", "123456"), EmployeeId = 1, EmailOk = true, ApprovedCode = "111111" }
                );

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
            }
        }
    }
}
