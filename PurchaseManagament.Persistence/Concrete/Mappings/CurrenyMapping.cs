using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Persistence.Concrete.Mappings
{
    public class CurrenyMapping : AuditableEntityMapping<Currency>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Currency> builder)
        {
            builder.ToTable("CURRENCIES");

            builder.Property(x => x.Name)
                .IsRequired().HasColumnName("CURRENCY_NAME").HasColumnType("nvarchar(20)");

            builder.HasMany(x => x.Offers)
                .WithOne(x => x.Currency)
                .HasForeignKey(builder => builder.CurrencyId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
