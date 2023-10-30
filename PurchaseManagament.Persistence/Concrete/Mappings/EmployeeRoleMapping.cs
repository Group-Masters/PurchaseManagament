using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Persistence.Concrete.Mappings
{
    public class EmployeeRoleMapping : AuditableEntityMapping<EmployeeRole>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<EmployeeRole> builder)
        {
            builder.ToTable("EMPLOYEE_ROLES");

            builder.Property(x => x.EmployeeId)
                .HasColumnName("EMPLOYEE_ID");

            builder.Property(x => x.RoleId)
                .HasColumnName("ROLE_ID");

            builder.HasOne(x => x.Employee)
                .WithMany(x => x.EmployeeRoles)
                .HasForeignKey(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Role)
                .WithMany(x => x.EmployeeRoles)
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
