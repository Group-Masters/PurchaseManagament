using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Persistence.Concrete.Mappings
{
    public class ProductMapping : AuditableEntityMapping<Product>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("PRODUCTS");

            builder.Property(x => x.MeasuringUnitId)
                .HasColumnName("MEASURING_UNIT_ID")
                .HasColumnOrder(2)
                .HasColumnType("bigint");

            builder.Property(x => x.Name)
                .HasColumnName("NAME")
                .HasColumnOrder(3);

            builder.Property(x => x.Description)
                .HasColumnName("DESCRIPTION")
                .HasColumnOrder(4);

            builder.HasOne(x => x.MeasuringUnit)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.MeasuringUnitId)
                .HasConstraintName("PRODUCT_MEASURING_UNITS");
        }
    }
}
