using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Persistence.Concrete.Mappings
{
    public class CurrencyMapping : BaseEntityMapping<Currency>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Currency> builder)
        {
            builder.Property(x => x.Name)
                .HasColumnName("CURRENCY_NAME")
                .HasColumnOrder(2)
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            builder.Property(x => x.Rate)
               .HasColumnName("CURRENCY_RATE")
               .HasColumnOrder(3)
               .IsRequired();
            
            builder.ToTable("CURRENCIES");
        }
    }
}
