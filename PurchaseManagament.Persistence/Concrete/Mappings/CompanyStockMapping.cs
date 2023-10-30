using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Persistence.Concrete.Mappings
{
    public class CompanyStockMapping : AuditableEntityMapping<CompanyStock>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<CompanyStock> builder)
        {
            builder.Property(x => x.CompanyId)
                .HasColumnOrder(2)
                .HasColumnType("bigint")
                .HasColumnName("COMPANY_ID")
                .IsRequired();

            builder.Property(x => x.ProductId)
                .HasColumnName("PRODUCT_ID")
                .HasColumnOrder(3);

            builder.HasOne(x => x.Company)
                .WithMany(x => x.CompanyStocks)
                .HasForeignKey(x => x.CompanyId)
                .HasConstraintName("COMPANY_STOCK_COMPANIES");

            builder.HasOne(x => x.Product)
                .WithMany(x => x.CompanyStocks)
                .HasForeignKey(x => x.ProductId)
                .HasConstraintName("COMPANY_DEPARTMENT_PRODUCTS");

            builder.ToTable("COMPANY_STOCK");
        }
    }
}
