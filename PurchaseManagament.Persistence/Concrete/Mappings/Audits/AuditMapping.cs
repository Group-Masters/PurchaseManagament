using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseManagament.Domain.Entities.Audits;

namespace PurchaseManagament.Persistence.Concrete.Mappings.Audits
{
    public class AuditMapping : IEntityTypeConfiguration<Audit>
    {
        public void Configure(EntityTypeBuilder<Audit> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("ID")
                .HasColumnOrder(1)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.MetaHashPrimaryKey)
                .HasColumnName("META_HASH_PRIMARY")
                .HasColumnOrder(2);

            builder.Property(x => x.MetaDisplayName)
                .HasColumnName("META_DISPLAY_NAME")
                .HasColumnOrder(3);

            builder.Property(x => x.OldValues)
                .HasColumnName("OLD_VALUES")
                .HasColumnOrder(4);

            builder.Property(x => x.NewValues)
                .HasColumnName("NEW_VALUES")
                .HasColumnOrder(5);

            builder.Property(x => x.DateTimeOffset)
                .HasColumnName("DATE_TIME")
                .HasColumnOrder(6);

            builder.Property(x => x.EntityState)
                .HasColumnName("ENTITY_STATE")
                .HasColumnOrder(7);

            builder.Property(x => x.UserId)
                .HasColumnName("USER_ID")
                .HasColumnOrder(8);

            builder.Property(x => x.UserName)
                .HasColumnName("USER_NAME")
                .HasColumnOrder(9);

            builder.HasOne(x => x.AuditMetaData)
                .WithMany(x => x.Audits)
                .HasForeignKey(x => new { x.MetaHashPrimaryKey, x.MetaDisplayName });

                
            builder.ToTable("AUDITS");
        }
    }
}
