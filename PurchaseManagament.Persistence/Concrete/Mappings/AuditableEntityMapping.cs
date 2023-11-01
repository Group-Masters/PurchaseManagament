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
                .HasColumnName("ID");
                

            ConfigureDerivedEntityMapping(builder);

            builder.Property(x => x.CreatedDate)
                .HasColumnName("CREATE_DATE")
                ;

            builder.Property(x => x.CreatedBy)
                .HasColumnName("CREATED_BY_ID")
                .HasColumnType("nvarchar(50)")
                .IsRequired(false)
                ;
            builder.Property(x => x.CreatedIP)
                .HasColumnName("CREATE_IP")
                .HasColumnType("nvarchar(100)")
                .IsRequired(false)
                ;

            builder.Property(x => x.ModifiedDate)
                .HasColumnName("MODIFIED_DATE");


            builder.Property(x => x.ModifiedBy)
                .HasColumnName("MODIFIED_BY_ID")
                .HasColumnType("nvarchar(50)")
                .IsRequired(false);
            builder.Property(x => x.ModifiedIP)
                .HasColumnName("MODIFIED_IP")
                .HasColumnType("nvarchar(100)")
                .IsRequired(false)
                ;

            builder.Property(x => x.IsActive)
                .HasColumnName("IS_ACTIVE")
                .IsRequired(false)
                ;
            builder.Property(x => x.IsDeleted)
                .HasColumnName("IS_DELETED")
                .HasDefaultValueSql("0");








        }
    }
}
