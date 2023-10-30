using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Persistence.Concrete.Mappings
{
    public class DepartmenMapping : AuditableEntityMapping<Department>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("DEPATMENTS");

            builder.Property(x => x.Name)
                .IsRequired().HasColumnName("DEPARTMENT_NAME").HasColumnType("nvarchar(50)");

            builder.HasMany(x => x.CompanyDepartments)
                .WithOne(x => x.Department)
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.NoAction);
                
        }
    }
}
