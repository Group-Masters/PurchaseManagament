using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Persistence.Concrete.Mappings
{
    public class SupplierMapping : AuditableEntityMapping<Supplier>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("SUPPLIERS");

            builder.Property(x => x.Address)
                .IsRequired().HasColumnName("SUPLIER_ADDRESS").HasColumnType("nvarchar(150)");

            builder.Property(x => x.Name)
                .IsRequired().HasColumnType("SUPLIER_NAME").HasColumnType("nvarchar(50)");

            
        }
    }
}
