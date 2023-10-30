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
            builder.Property(x => x.CompanyDepartmentId).IsRequired().HasColumnName("COMPANY_DEPARTMENT_ID");

            builder.Property(x => x.Name).IsRequired().HasColumnName("EMPLOYEE_NAME").HasColumnType("nvarchar(20)");
            builder.Property(x => x.Surname).IsRequired().HasColumnName("EMPLOYEE_SURNAME").HasColumnType("nvarchar(20)");
            builder.Property(x => x.BirthYear).IsRequired().HasColumnName("BIRTH_YEAR").HasColumnType("nvarchar(4)");
            builder.Property(x => x.Gender).IsRequired().HasColumnName("GENDER");

            builder.Property(x => x.IdNumber).IsRequired().HasColumnName("EMPLOYEE_ID_NUMBER");
            
            

         

           

            builder.HasOne(x => x.CompanyDepartment)
                .WithMany(x => x.Employes)
                .HasForeignKey(x => x.CompanyDepartmentId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
