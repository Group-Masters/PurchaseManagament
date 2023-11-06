using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PurchaseManagament.Domain.Common;

namespace PurchaseManagament.Persistence.Concrete.Mappings
{
    public abstract class BaseEntityMapping<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public abstract void ConfigureDerivedEntityMapping(EntityTypeBuilder<T> builder);

        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("ID")
                .HasColumnOrder(1);

            //Interceptor
            ConfigureDerivedEntityMapping(builder);

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
