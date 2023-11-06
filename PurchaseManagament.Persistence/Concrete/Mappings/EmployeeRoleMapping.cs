using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Persistence.Concrete.Mappings
{
    public class EmployeeRoleMapping : BaseEntityMapping<EmployeeRole>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<EmployeeRole> builder)
        {

            builder.Property(x => x.EmployeeId)
                .HasColumnName("EMPLOYEE_ID")
                .HasColumnOrder(2);

            builder.Property(x => x.RoleId)
                .HasColumnName("ROLE_ID")
                .HasColumnOrder(3);

            builder.HasOne(x => x.Employee)
                .WithMany(x => x.EmployeeRoles)
                .HasForeignKey(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Role)
                .WithMany(x => x.EmployeeRoles)
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("EMPLOYEE_ROLES");
        }
    }
}
