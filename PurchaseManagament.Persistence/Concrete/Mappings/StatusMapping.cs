using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Persistence.Concrete.Mappings
{
    public class StatusMapping : AuditableEntityMapping<Status>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("STATUS");

            builder.Property(x => x.StatusName)
                .IsRequired().HasColumnName("STATUS_NAME").HasColumnType("nvarchar(20)");

            builder.HasMany(x => x.Offers)
                .WithOne(x => x.Status).HasForeignKey(x => x.StatusId);

            builder.HasMany(x => x.Requests)
                .WithOne(builder => builder.Status).HasForeignKey(x => x.StatusId);
        }
    }
}
