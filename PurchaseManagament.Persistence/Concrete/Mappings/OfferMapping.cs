using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Persistence.Concrete.Mappings
{
    public class OfferMapping : AuditableEntityMapping<Offer>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Offer> builder)
        {
            builder.ToTable("OFFERS");

            builder.Property(x => x.CurrencyId)
                .HasColumnName("CURRENCY_ID").HasColumnType("BigInt");

            builder.Property(builder => builder.OfferedPrice)
                .HasColumnName("OFFERED_PRICE").HasColumnType("BigInt");

            builder.Property(builder => builder.RequestId)
                .HasColumnName("REQUEST_ID").HasColumnType("BigInt");
           
            builder.Property(builder => builder.Status)
                .HasColumnName("STATUS");

            builder.Property(builder => builder.ApprovingEmployeeId)
                .HasColumnName("APPROVING_EMPLOYEE_ID")
               
                .IsRequired(false);


            builder.Property(builder => builder.SupplierId)
                .HasColumnName("SUPLIER_ID").HasColumnType("BigInt");

            builder.HasOne(x => x.Supplier)
                .WithMany(x => x.Offers)
                .HasForeignKey(x => x.SupplierId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.ApprovingEmployee)
                .WithMany(x => x.Offers)
                .HasForeignKey(builder => builder.ApprovingEmployeeId)
                .OnDelete(DeleteBehavior.NoAction);

            

            builder.HasOne(x => x.Currency)
                .WithMany(x => x.Offers)
                .HasForeignKey(x => x.CurrencyId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Request)
                .WithMany (x => x.Offers).HasForeignKey(x => x.RequestId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
