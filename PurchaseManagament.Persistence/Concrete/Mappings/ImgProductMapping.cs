using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseManagament.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Persistence.Concrete.Mappings
{
    public class ImgProductMapping : AuditableEntityMapping<ImgProduct>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<ImgProduct> builder)
        {

            builder.ToTable("IMG_PRODUCT");

            builder.Property(x => x.ProductId)
                .HasColumnName("PRODUCT_ID")
                .HasColumnOrder(2)
                .HasColumnType("BigInt")
                .IsRequired();

            builder.Property(x => x.ImageSrc)
                .HasColumnName("IMAGE_SRC")
                .HasColumnOrder(3)
                .HasColumnType("nvarchar(150)")
                .IsRequired();


            builder.HasOne(x => x.Product)
             .WithOne(x => x.ImgProduct)
             .HasForeignKey<ImgProduct>(x => x.ProductId)
             .HasConstraintName("PRODUCT_IMG")
             .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
