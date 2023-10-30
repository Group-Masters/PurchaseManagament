using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Persistence.Concrete.Mappings
{
    public class RoleMapping : AuditableEntityMapping<Role>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("ROLES");

            builder.Property(x => x.Name).IsRequired().HasColumnName("ROLE_NAME").HasColumnType("nvarchar(20)");

            builder.HasMany(x => x.EmployeeRoles)
                .WithOne(x => x.Role).HasForeignKey(x => x.RoleId);
        }
    }
}
