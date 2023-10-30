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
                .HasColumnType("bigint")
                .HasColumnOrder(2)
                .IsRequired();

            builder.Property(x => x.UUID)
                .HasColumnOrder(3)
                .HasColumnType("UNIQUEIDENTIFIER")
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
