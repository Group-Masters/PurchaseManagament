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

            builder.Property(x => x.OldValues)
                .HasColumnName("OLD_VALUES")
                .HasColumnOrder(2);

            builder.Property(x => x.NewValues)
                .HasColumnName("NEW_VALUES")
                .HasColumnOrder(3);

            builder.Property(x => x.DateTimeOffset)
                .HasColumnName("DATE_TIME")
                .HasColumnOrder(4);

            builder.Property(x => x.EntityState)
                .HasColumnName("ENTITY_STATE")
                .HasColumnOrder(5);

            builder.Property(x => x.UserId)
                .HasColumnName("USER_ID")
                .HasColumnOrder(6);

            builder.Property(x => x.UserName)
                .HasColumnName("USER_NAME")
                .HasColumnOrder(7);
                
            builder.ToTable("AUDITS");
        }
    }
}
