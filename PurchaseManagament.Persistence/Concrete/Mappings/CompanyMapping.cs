using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Persistence.Concrete.Mappings
{
    public class CompanyMapping : AuditableEntityMapping<Company>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Company> builder)
        {
            builder.Property(x => x.Name)
                .HasColumnName("NAME")
                .HasColumnOrder(2)
                .HasColumnType("nvarchar(50)");

            builder.Property(x => x.Address)
              .HasColumnName("ADDRESS")
              .HasColumnOrder(3)
              .HasColumnType("nvarchar(150)");
          
            builder.Property(x => x.ManagerThreshold)
              .HasColumnName("MANAGER_THRESHOLD");
              

            builder.ToTable("COMPANIES");
        }
    }
}
