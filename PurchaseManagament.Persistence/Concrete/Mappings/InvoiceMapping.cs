using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Persistence.Concrete.Mappings
{
    public class InvoiceMapping : AuditableEntityMapping<Invoice>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Invoice> builder)
        {
            builder.Property(x => x.OfferId)
                .HasColumnName("OFFER_ID")
                .HasColumnOrder(2)
                .HasColumnType("bigint")
                .IsRequired();

            builder.Property(x => x.UUID)
                .HasColumnType("UNIQUEIDENTIFIER")
                .HasColumnOrder(3)
                .IsRequired();

            builder.Property(x => x.Status)
                .HasColumnName("STATUS")
                .HasColumnOrder(4);

            builder.Property(x => x.ImageSrc)
               .HasColumnName("IMAGE_SRC")
               .HasColumnOrder(5)
               .HasColumnType("nvarchar(150)");
            
            builder.Property(x => x.TRY_Rate)
               .HasColumnName("TRY_RATE")
               .HasColumnOrder(6);
               

            builder.HasOne(x => x.Offer)
                .WithOne(x => x.Invoice)
                .HasForeignKey<Invoice>(x => x.OfferId)
                .HasConstraintName("INVOICES_ORDER")
                .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("INVOICES");
        }
    }
}
