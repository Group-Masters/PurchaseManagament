using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Persistence.Concrete.Mappings
{
    public class StockOperationMapping : AuditableEntityMapping<StockOperations>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<StockOperations> builder)
        {

            builder.Property(x => x.CompanyStockId)
                .HasColumnName("COMPANY_STOCK_ID")
                .HasColumnOrder(2)
                .IsRequired();

            builder.Property(x => x.ReceivingEmployeeId)
                .HasColumnName("RECEIVING_EMPLOYEE")
                .HasColumnOrder(3)
                .IsRequired();

            builder.Property(x => x.Quantity)
                .HasColumnName("QUANTITY")
                .HasColumnOrder(4)
                .IsRequired();

            builder.HasOne(x => x.CompanyStock)
                .WithMany(x => x.StockOperations)
                .HasForeignKey(x => x.CompanyStockId)
                .HasConstraintName("STOCK_OPERATIONS_COMPANY_STOCK")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Employee)
                .WithMany(x => x.StockOperations)
                .HasForeignKey(x => x.ReceivingEmployeeId)
                .HasConstraintName("STOCK_OPERATIONS_RECEIVING_EMPLOYEE");

            builder.ToTable("STOCK_OPERATIONS");
        }
    }
}
