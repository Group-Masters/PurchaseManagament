using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Persistence.Concrete.Mappings
{
    public class EmployeeMapping : AuditableEntityMapping<Employee>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("EMPLOYEES");

            builder.Property(x => x.Name).IsRequired().HasColumnName("EMPLOYEE_NAME").HasColumnType("nvarchar(20)");
            builder.Property(x => x.Surname).IsRequired().HasColumnName("EMPLOYEE_SURNAME").HasColumnType("nvarchar(20)");
            builder.Property(x => x.BirthDate).IsRequired().HasColumnName("EMPLOYEE_BIRHDATE");
            builder.Property(x => x.Email).IsRequired().HasColumnName("EMPLOYEE_EMAIL").HasColumnType("nvarchar(20)");
            builder.Property(x => x.IdNumber).IsRequired().HasColumnName("EMPLOYEE_ID_NUMBER");
            builder.Property(x => x.Password).IsRequired().HasColumnName("EMPLOYEE_PASSWORD").HasColumnType("nvarchar(50)");
            builder.Property(x => x.Phone).IsRequired().HasColumnName("EMPLOYEE_PHONE").HasColumnType("nvarchar(20)");
            

            builder.HasMany(x => x.Offers)
                .WithOne(x => x.ApprovingEmployee)
                .HasForeignKey(x => x.ApprovingEmployeeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.EmployeeRoles)
                .WithOne(x => x.Employee)
                .HasForeignKey(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.CompanyDepartment)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.CompanyDepartmentId).OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.Requests)
                .WithOne(x => x.ApprovedEmployee)
                .HasForeignKey(x => x.approvingEmployeeId).OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.Requests)
               .WithOne(x => x.RequestEmployee)
               .HasForeignKey(x => x.RequestEmployeeId).OnDelete(DeleteBehavior.NoAction);





        }
    }
}
