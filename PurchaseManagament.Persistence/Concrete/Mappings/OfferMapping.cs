using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Persistence.Concrete.Mappings
{
    public class OfferMapping : AuditableEntityMapping<Offer>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Offer> builder)
        {

            builder.Property(x => x.CurrencyId)
                .HasColumnName("CURRENCY_ID")
                .HasColumnOrder(2)
                .HasColumnType("BigInt");

            builder.Property(x => x.SupplierId)
                .HasColumnName("SUPPLIER_ID")
                .HasColumnOrder(3)
                .HasColumnType("BigInt");
            
            builder.Property(x => x.ApprovingEmployeeId)
                .HasColumnName("APPROVING_EMPLOYEE_ID")
                .HasColumnOrder(5)
                .IsRequired(false);


            builder.Property(x => x.Details)
                .HasColumnName("DETAILS")
                .HasColumnOrder(7)
                .HasColumnType("nvarchar(250)");

            builder.Property(x => x.Status)
                .HasColumnName("STATUS")
                .HasColumnOrder(8);

            builder.HasOne(x => x.Supplier)
                .WithMany(x => x.Offers)
                .HasForeignKey(x => x.SupplierId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.ApprovingEmployee)
                .WithMany(x => x.Offers)
                .HasForeignKey(x => x.ApprovingEmployeeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Currency)
                .WithMany(x => x.Offers)
                .HasForeignKey(x => x.CurrencyId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder.ToTable("OFFERS");
        }
    }
}
