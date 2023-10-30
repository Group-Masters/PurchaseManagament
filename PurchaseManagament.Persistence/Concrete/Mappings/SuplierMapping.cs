using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Persistence.Concrete.Mappings
{
    public class SuplierMapping : AuditableEntityMapping<Supplier>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("SUPLIERS");

            builder.Property(x => x.Address)
                .IsRequired().HasColumnName("SUPLIER_ADDRESS").HasColumnType("nvarchar(150)");

            builder.Property(x => x.Name)
                .IsRequired().HasColumnType("SUPLIER_NAME").HasColumnType("nvarchar(50)");

            builder.HasMany(x => x.Offers)
                .WithOne(x => x.Supplier).HasForeignKey(x => x.SupplierId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
