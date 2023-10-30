using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Persistence.Concrete.Mappings
{
    public class EmployeeDetailMapping : AuditableEntityMapping<EmployeeDetail>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<EmployeeDetail> builder)
        {
            builder.Property(x => x.EmployeeId)
                .HasColumnOrder(2)
                .HasColumnName("EMPLOYEE_ID")
                .IsRequired();

            builder.Property(x => x.EmailOk)
                .HasColumnType("bit")
                .HasDefaultValue(false)
                .HasColumnOrder(3);

            builder.Property(x => x.ApprovedCode)
                .HasColumnType("nvarchar(15)")
                .HasDefaultValue(false)
                .HasColumnOrder(3);

            builder.HasOne(x => x.Employee)
                .WithOne(x => x.EmployeeDetail)
                .HasForeignKey<EmployeeDetail>(x => x.EmployeeId)
                .HasConstraintName("EMPLOYEE_DETAIL")
                .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("EMPLOYEE_DETAILS");
        }
    }
}
