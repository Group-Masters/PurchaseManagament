using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Persistence.Concrete.Mappings
{
    public class SupplierMapping : BaseEntityMapping<Supplier>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Supplier> builder)
        {
            builder.Property(x => x.Name)
                .HasColumnName("NAME")
                .HasColumnOrder(2)
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            builder.Property(x => x.Address)
                .HasColumnName("ADDRESS")
                .HasColumnOrder(3)
                .HasColumnType("nvarchar(150)")
                .IsRequired();

            builder.ToTable("SUPPLIERS");
        }
    }
}
