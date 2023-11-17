using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Persistence.Concrete.Mappings
{
    public class RequestMapping : AuditableEntityMapping<Request>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Request> builder)
        {
            builder.Property(x => x.ProductId)
                .HasColumnName("PRODUCT_ID")
                .HasColumnOrder(2)
                .HasColumnType("bigint");

            builder.Property(x => x.ApprovingEmployeeId)
                .HasColumnName("APPROVING_EMPLOYEE_ID")
                .HasColumnOrder(3)
                .HasColumnType("bigint")
                .IsRequired(false);

            builder.Property(x => x.RequestEmployeeId)
                .HasColumnName("REQUEST_EMPLOYEE_ID")
                .HasColumnOrder(4)
                .HasColumnType("bigint");

            builder.Property(x => x.Details)
                .HasColumnName("DETAILS")
                .HasColumnOrder(5);

            builder.Property(x => x.Quantity)
                .HasColumnName("QUANTITY")
                .HasColumnOrder(6);
          
            builder.Property(x => x.State)
                .HasColumnName("STATUS")
                .HasColumnOrder(7);
            builder.Property(x => x.ApprovedDate)
               .HasColumnName("APPROVED_DATE")
               .HasColumnOrder(8);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.Requests)
                .HasForeignKey(x => x.ProductId)
                .HasConstraintName("REQUEST_PRODUCTS");

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
