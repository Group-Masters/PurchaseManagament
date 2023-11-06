using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Persistence.Concrete.Mappings
{
    public class StockOperationMapping : AuditableEntityMapping<StockOperations>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<StockOperations> builder)
        {
            builder.Property(x  => x.Quantity)
                .HasColumnName("QUANTITY")
                .HasColumnOrder(2)
                .IsRequired();

            builder.Property(x => x.CompanyStockId)
                .HasColumnName("COMPANY_STOCK_ID")
                .HasColumnOrder(3)
                .IsRequired();

            builder.Property(x => x.ReceiverEmployeeId)
                .HasColumnName("RECEIVER_EMPLOYEE_ID")
                .HasColumnOrder(4)
                .IsRequired();

            builder.Property(x => x.ProductId)
                .HasColumnName("PRODUCT_ID")
                .HasColumnOrder(5)
                .IsRequired();

            builder.Property(x => x.Quantity)
                .HasColumnName("QUANTITY")
                .HasColumnOrder(6)
                .IsRequired();

            builder.Property(x => x.Notification)
                .HasColumnName("NOTIFICATION")
                .HasColumnOrder(7)
                .IsRequired();

            builder.HasOne(x => x.CompanyStock)
                .WithMany(x => x.StockOperations)
                .HasForeignKey(x => x.CompanyStockId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.StockOperations)
                .HasForeignKey(x => x.ProductId); 
           
            builder.HasOne(x => x.ReceiverEmployee)
                .WithMany(x => x.StockOperations)
                .HasForeignKey(x => x.ReceiverEmployeeId);

            builder.ToTable("STOCK_OPERATIONS");          
        }
    }
}
