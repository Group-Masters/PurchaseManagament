using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Persistence.Concrete.Mappings
{
    public class StockOperationMapping : AuditableEntityMapping<StockOperations>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<StockOperations> builder)
        {
            builder.ToTable("STOCK_OPERATIONS");

            builder.Property(x  => x.Quantity).IsRequired().HasColumnName("QUANTITY");
            builder.Property(x => x.CompanyStockId).IsRequired().HasColumnName("COMPANYSTOCK_ID");
            builder.Property(x => x.ReceiverEmployeeId).IsRequired().HasColumnName("RECEIVER_EMPLOYEE_ID");

            builder.HasOne(x => x.CompanyStock)
                .WithMany(x => x.StockOperations).HasForeignKey(x => x.CompanyStockId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.StockOperations)
                .HasForeignKey(x => x.ProductId); 
           
            builder.HasOne(x => x.ReceiverEmployee)
                .WithMany(x => x.StockOperations)
                .HasForeignKey(x => x.ReceiverEmployeeId);
          
        }
    }
}
