using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Persistence.Concrete.Mappings
{
    public class CompanyDepartmentMapping : AuditableEntityMapping<CompanyDepartment>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<CompanyDepartment> builder)
        {
            builder.Property(x => x.CompanyId)
                .HasColumnOrder(2)
                .HasColumnType("bigint")
                .HasColumnName("COMPANY_ID")
                .IsRequired();

            builder.Property(x => x.DepartmentId)     
                .HasColumnName("DEPARTMENT_ID")
                .HasColumnOrder(3);


            builder.HasOne(x => x.Company)
                .WithMany(x => x.CompanyDepartments)
                .HasForeignKey(x => x.CompanyId)
                .HasConstraintName("COMPANY_DEPARTMENT_COMPANIES");

            builder.HasOne(x => x.Department)
                .WithMany(x => x.CompanyDepartments)
                .HasForeignKey(x => x.DepartmentId)
                .HasConstraintName("COMPANY_DEPARTMENT_DEPARTMENTS");

            builder.ToTable("COMPANY_DEPARTMENTS");
        }
    }
}
