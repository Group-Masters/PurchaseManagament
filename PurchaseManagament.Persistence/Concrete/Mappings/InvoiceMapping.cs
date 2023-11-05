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

            builder.HasOne(x => x.Offer)
                .WithOne(x => x.Invoice)
                .HasForeignKey<Invoice>(x => x.OfferId)
                .HasConstraintName("INVOICES_ORDER")
                .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("INVOICES");
        }
    }
}
