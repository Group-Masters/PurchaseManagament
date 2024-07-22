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
                .HasColumnType("varchar(50)");

            builder.Property(x => x.Address)
              .HasColumnName("ADDRESS")
              .HasColumnOrder(3)
              .HasColumnType("varchar(150)");
          
            builder.Property(x => x.ManagerThreshold)
              .HasColumnName("MANAGER_THRESHOLD");
              

            builder.ToTable("COMPANIES");
        }
    }
}
