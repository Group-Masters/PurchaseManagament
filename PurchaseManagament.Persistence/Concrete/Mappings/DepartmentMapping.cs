using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Persistence.Concrete.Mappings
{
    public class DepartmentMapping : AuditableEntityMapping<Department>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Department> builder)
        {
            builder.Property(x => x.Name)
                .HasColumnName("DEPARTMENT_NAME")
                .HasColumnOrder(2)
                .HasColumnType("nvarchar(50)")
                .IsRequired();

           builder.ToTable("DEPARTMENTS");
        }
    }
}
