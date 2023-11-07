using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Audit
{
    public class AuditMetaDataEntityConfiguration : IEntityTypeConfiguration<AuditMetaDataEntity>
    {
        public AuditMetaDataEntityConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<AuditMetaDataEntity> builder)
        {
            #region Configuration
            builder.ToTable("AUDIT_META_DATAS");
            builder.HasKey(x => new { x.HashPrimaryKey, x.SchemaTable });

            builder.Property(x => x.ReadablePrimaryKey)
                .HasColumnName("READABLE_PRIMARY_KEY")
                .HasColumnOrder(2);

            builder.Property(x => x.Schema)
                .HasColumnName("SCHEMA")
                .HasColumnOrder(3);

            builder.Property(x => x.Table)
                .HasColumnName("TABLE")
                .HasColumnOrder(4);

            builder.Property(x => x.DisplayName)
                .HasColumnName("DISPLAY_NAME")
                .HasColumnOrder(5);
            #endregion
        }
    }
}
