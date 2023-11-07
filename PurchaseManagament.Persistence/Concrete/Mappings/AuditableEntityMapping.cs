using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PurchaseManagament.Domain.Common;

namespace PurchaseManagament.Persistence.Concrete.Mappings
{
    public abstract class AuditableEntityMapping<T> : IEntityTypeConfiguration<T> where T : AuditableEntity
    {
        public abstract void ConfigureDerivedEntityMapping(EntityTypeBuilder<T> builder);

        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("ID")
                .HasColumnOrder(1);

            ConfigureDerivedEntityMapping(builder);

            builder.Property(x => x.CreatedBy)
                .HasColumnName("CREATED_BY_ID")
                .HasColumnOrder(47)
                .HasColumnType("nvarchar(50)")
                .IsRequired(false);            
            
            builder.Property(x => x.CreatedDate)
                .HasColumnName("CREATED_DATE")
                .HasColumnOrder(47)
                .IsRequired(false);

            builder.Property(x => x.IsActive)
                .HasColumnName("IS_ACTIVE")
                .HasColumnOrder(49)
                .HasDefaultValueSql("1");

            builder.Property(x => x.IsDeleted)
                .HasColumnName("IS_DELETED")
                .HasColumnOrder(50)
                .HasDefaultValueSql("0");
        }
    }
}
