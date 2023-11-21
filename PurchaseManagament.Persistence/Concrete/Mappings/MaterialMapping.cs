using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Persistence.Concrete.Mappings
{
    public class MaterialMapping : AuditableEntityMapping<Material>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Material> builder)
        {
            builder.Property(x => x.RequestId)
                .HasColumnName("APPROVING_EMPLOYEE_ID")
                .HasColumnOrder(2)
                .HasColumnType("bigint")
                .IsRequired(false);

            builder.Property(x => x.ProductId)
                .HasColumnName("REQUEST_EMPLOYEE_ID")
                .HasColumnOrder(3)
                .HasColumnType("bigint");

            builder.Property(x => x.Details)
                .HasColumnName("STATUS")
                .HasColumnOrder(4);

            builder.Property(x => x.Quantity)
               .HasColumnName("APPROVED_DATE")
               .HasColumnOrder(5);

            builder.HasOne(x => x.Request)
                .WithMany(x => x.Materials)
                .HasForeignKey(x => x.RequestId)
                .HasConstraintName("MATERIAL_REQUEST")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.Materials)
                .HasForeignKey(x => x.ProductId)
                .HasConstraintName("MATERIAL_PRODUCT")
                .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("MATERIALS");
        }
    }
}
