using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Persistence.Concrete.Mappings
{
    public class RequestMapping : AuditableEntityMapping<Request>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Request> builder)
        {
            builder.Property(x => x.RequestEmployeeId)
                .HasColumnName("REQUEST_EMPLOYEE_ID")
                .HasColumnOrder(2)
                .HasColumnType("bigint");


            builder.Property(x => x.Description)
               .HasColumnName("DESCRIPTION")
               .HasColumnOrder(3);

            builder.Property(x => x.State)
                .HasColumnName("STATUS")
                .HasColumnOrder(4);

            builder.HasOne(x => x.RequestEmployee)
                .WithMany(x => x.EmployeeRequests)
                .HasForeignKey(x => x.RequestEmployeeId)
                .HasConstraintName("REQUEST_REQUEST_EMPLOYEE")
                .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("REQUESTS");
        }
    }
}
