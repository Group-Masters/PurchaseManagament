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
                .HasColumnName("EMPLOYEE_ID")
                .HasColumnOrder(2)
                .IsRequired(); 

            builder.Property(x => x.Username)
                .HasColumnName("USERNAME")
                .HasColumnOrder(3)
                .IsRequired();

            builder.Property(x => x.Address)
                .HasColumnName("ADDRESS")
                .HasColumnOrder(4)
                .IsRequired();
           
            builder.Property(x => x.Email)
                .HasColumnName("EMAIL")
                .HasColumnOrder(5)
                .HasColumnType("nvarchar(150)")
                .IsRequired();

            builder.Property(x => x.Password)
                .HasColumnName("PASSWORD")
                .HasColumnOrder(6)
                .HasColumnType("nvarchar(50)")
                .IsRequired();
         
            builder.Property(x => x.Phone)
                .HasColumnName("PHONE")
                .HasColumnOrder(7)
                .HasColumnType("nvarchar(20)")
                .IsRequired();

            builder.Property(x => x.EmailOk)
                .HasColumnName("EMAIL_OK")
                .HasColumnOrder(8)
                .HasColumnType("bit")
                .HasDefaultValue(false);

            builder.Property(x => x.ApprovedCode)
                .HasColumnName("APPROVED_CODE")
                .HasColumnOrder(9)
                .HasColumnType("nvarchar(15)");

            builder.HasOne(x => x.Employee)
                .WithOne(x => x.EmployeeDetail)
                .HasForeignKey<EmployeeDetail>(x => x.EmployeeId)
                .HasConstraintName("EMPLOYEE_DETAIL")
                .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("EMPLOYEE_DETAILS");
        }
    }
}
