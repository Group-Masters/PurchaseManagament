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
            builder.Property(x => x.Surname).IsRequired().HasColumnName("EMPLOYEE_SURNAME").HasColumnType("nvarchar(20)");
            builder.Property(x => x.Surname).IsRequired().HasColumnName("EMPLOYEE_SURNAME").HasColumnType("nvarchar(20)");
           builder.Property(x => x.IdNumber).IsRequired().HasColumnName("EMPLOYEE_ID_NUMBER");
            
            

            builder.HasMany(x => x.Offers)
                .WithOne(x => x.ApprovingEmployee)
                .HasForeignKey(x => x.ApprovingEmployeeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.EmployeeRoles)
                .WithOne(x => x.Employee)
                .HasForeignKey(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.CompanyDepartment)
                .WithMany(x => x.Employes)
                .HasForeignKey(x => x.CompanyDepartmentId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
