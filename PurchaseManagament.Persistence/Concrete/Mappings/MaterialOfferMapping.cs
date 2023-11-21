using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Persistence.Concrete.Mappings
{
    public class MaterialOfferMapping : AuditableEntityMapping<MaterialOffer>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<MaterialOffer> builder)
        {
            builder.Property(x => x.OfferId)
                .HasColumnName("OFFER_ID")
                .HasColumnOrder(2)
                .HasColumnType("bigint")
                .IsRequired();

            builder.Property(x => x.MaterialId)
                .HasColumnName("MATERIAL_ID")
                .HasColumnOrder(3)
                .HasColumnType("bigint")
                .IsRequired();

            builder.HasOne(x => x.Offer)
                .WithMany(x => x.MaterialOffers)
                .HasForeignKey(x => x.OfferId)
                .HasConstraintName("MATERIAL_OFFERS_OFFER");

            builder.HasOne(x => x.Material)
                .WithMany(x => x.MaterialOffers)
                .HasForeignKey(x => x.MaterialId)
                .HasConstraintName("MATERIAL_OFFERS_MATERIAL");

            builder.ToTable("MATERIAL_OFFERS");
        }
    }
}
