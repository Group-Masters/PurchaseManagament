using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Persistence.Concrete.Mappings
{
    public class CompanyMapping : BaseEntityMapping<Company>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Company> builder)
        {
            builder.Property(x => x.Name)
                .HasColumnName("NAME")
                .HasColumnOrder(2)
                .HasColumnType("nvarchar(50)");

            builder.Property(x => x.Adress)
              .HasColumnName("ADDRESS")
              .HasColumnOrder(3)
              .HasColumnType("nvarchar(150)");

            builder.ToTable("COMPANIES");
        }
    }
}
