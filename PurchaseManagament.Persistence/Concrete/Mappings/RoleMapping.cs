using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Persistence.Concrete.Mappings
{
    public class RoleMapping : AuditableEntityMapping<Role>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Role> builder)
        {
            builder.Property(x => x.Name)
                .HasColumnName("ROLE_NAME")
                .HasColumnOrder(2)
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            builder.ToTable("ROLES");
        }
    }
}
