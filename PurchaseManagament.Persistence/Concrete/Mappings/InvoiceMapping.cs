using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Persistence.Concrete.Mappings
{
    public class InvoiceMapping : AuditableEntityMapping<Invoice>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Invoice> builder)
        {
            builder.Property(x => x.UUID)
                .HasColumnType("UNIQUEIDENTIFIER")
                .HasColumnOrder(2)
                .IsRequired();

            builder.Property(x => x.Status)
                .HasColumnName("STATUS")
                .HasColumnOrder(3);

            builder.Property(x => x.ImageSrc)
               .HasColumnName("IMAGE_SRC")
               .HasColumnOrder(4)
               .HasColumnType("nvarchar(150)");

            builder.Property(x => x.TRY_Rate)
               .HasColumnName("TRY_RATE")
               .HasColumnOrder(5);

            builder.ToTable("INVOICES");
        }
    }
}
