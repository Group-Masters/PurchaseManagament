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
            #endregion
        }
    }
}
