using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Persistence.Concrete.Mappings
{
    public class EmployeeMapping : AuditableEntityMapping<Employee>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(x => x.CompanyDepartmentId)
                .HasColumnName("COMPANY_DEPARTMENT_ID")
                .HasColumnOrder(2)
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnName("NAME")
                .HasColumnOrder(3)
                .HasColumnType("nvarchar(20)")
                .IsRequired();

            builder.Property(x => x.Surname)
                .HasColumnName("SURNAME")
                .HasColumnOrder(4)
                .HasColumnType("nvarchar(20)")
                .IsRequired();

            builder.Property(x => x.IdNumber)
                .HasColumnName("ID_NUMBER")
                .HasColumnOrder(5)
                .IsRequired();

            builder.Property(x => x.BirthYear)
                .HasColumnName("BIRTH_YEAR")
                .HasColumnOrder(6)
                .HasColumnType("nvarchar(4)")
                .IsRequired();

            builder.Property(x => x.Gender)
                .HasColumnName("GENDER")
                .HasColumnOrder(7)
                .IsRequired();

            builder.HasOne(x => x.CompanyDepartment)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.CompanyDepartmentId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder.ToTable("EMPLOYEES");
        }
    }
}
