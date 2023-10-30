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
            builder.Property(x => x.Username)
                
                .HasColumnName("USERNAME")
                .IsRequired();
            builder.Property(x => x.Adress)
              
                .HasColumnName("ADDRESS")
                .IsRequired();
           
            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName("EMPLOYEE_EMAIL")
                .HasColumnType("nvarchar(150)");

            builder.Property(x => x.Password)
                .IsRequired()
                .HasColumnName("EMPLOYEE_PASSWORD")
                .HasColumnType("nvarchar(50)");
         
            builder.Property(x => x.Phone)
                .IsRequired()
                .HasColumnName("EMPLOYEE_PHONE")
                .HasColumnType("nvarchar(20)");

            builder.Property(x => x.EmailOk)
                .HasColumnType("bit")
                .HasDefaultValue(false)
                .HasColumnOrder(3);

            builder.Property(x => x.ApprovedCode)
                .HasColumnType("nvarchar(15)")
                .HasColumnOrder(4);

            builder.HasOne(x => x.Employee)
                .WithOne(x => x.EmployeeDetail)
                .HasForeignKey<EmployeeDetail>(x => x.EmployeeId)
                .HasConstraintName("EMPLOYEE_DETAIL")
                .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("EMPLOYEE_DETAILS");
        }
    }
}
