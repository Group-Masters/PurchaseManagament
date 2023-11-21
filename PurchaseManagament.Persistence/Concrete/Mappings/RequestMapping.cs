using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Persistence.Concrete.Mappings
{
    public class RequestMapping : AuditableEntityMapping<Request>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Request> builder)
        {
            builder.Property(x => x.ApprovingEmployeeId)
                .HasColumnName("APPROVING_EMPLOYEE_ID")
                .HasColumnOrder(2)
                .HasColumnType("bigint")
                .IsRequired(false);

            builder.Property(x => x.RequestEmployeeId)
                .HasColumnName("REQUEST_EMPLOYEE_ID")
                .HasColumnOrder(3)
                .HasColumnType("bigint");

            builder.Property(x => x.State)
                .HasColumnName("STATUS")
                .HasColumnOrder(4);

            builder.Property(x => x.ApprovedDate)
               .HasColumnName("APPROVED_DATE")
               .HasColumnOrder(5);

            builder.Property(x => x.Description)
               .HasColumnName("DESCRIPTION")
               .HasColumnOrder(6);

            builder.HasOne(x => x.ApprovedEmployee)
                .WithMany(x => x.ApprovedRequests)
                .HasForeignKey(x => x.ApprovingEmployeeId)
                .HasConstraintName("REQUEST_APPROVING_EMPLOYEE")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.RequestEmployee)
                .WithMany(x => x.EmployeeRequests)
                .HasForeignKey(x => x.RequestEmployeeId)
                .HasConstraintName("REQUEST_REQUEST_EMPLOYEE")
                .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("REQUESTS");
        }
    }
}
