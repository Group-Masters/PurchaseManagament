using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Persistence.Concrete.Mappings
{
    public class MeasuringUnitMapping : AuditableEntityMapping<MeasuringUnit>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<MeasuringUnit> builder)
        {
            builder.Property(x => x.Name)
                .HasColumnName("NAME")
                .HasColumnOrder(2)
                .HasColumnType("nvarchar(20)")
                .IsRequired();

            builder.ToTable("MEASURING_UNIT");
        }
    }
}
