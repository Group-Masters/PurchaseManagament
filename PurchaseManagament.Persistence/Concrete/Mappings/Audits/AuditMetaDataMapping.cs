using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseManagament.Domain.Entities.Audits;

namespace PurchaseManagament.Persistence.Concrete.Mappings.Audits
{
    public class AuditMetaDataMapping : IEntityTypeConfiguration<AuditMetaData>
    {
        public void Configure(EntityTypeBuilder<AuditMetaData> builder)
        {
            builder.ToTable("AUDIT_META_DATAS");
            builder.HasKey(x => new { x.HashPrimaryKey, x.DisplayName });

            builder.Property(x => x.ReadablePrimaryKey)
                .HasColumnName("READABLE_PRIMARY_KEY")
                .HasColumnOrder(2);

            builder.Property(x => x.Table)
                .HasColumnName("TABLE")
                .HasColumnOrder(3);

            builder.Property(x => x.DisplayName)
                .HasColumnName("DISPLAY_NAME")
                .HasColumnOrder(4);

            builder.ToTable("AUDIT_META_DATAS");
        }
    }
}
