using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseManagament.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Persistence.Concrete.Mappings
{
    public class PageEntityMapping : AuditableEntityMapping<Page>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Page> builder)
        {
            builder.Property(x => x.PageName)
                .HasColumnName("PAGE_NAME")
                .HasColumnOrder(2)
                .HasColumnType("nvarchar(50)");

            builder.Property(x => x.UpperPageId)
              .HasColumnName("UPPPER_PAGE_ID")
              .HasColumnOrder(3)
              .IsRequired(false);

            builder.Property(x => x.Content)
              .HasColumnName("CONTENT")
                .HasColumnOrder(4)
                .HasColumnType("nvarchar(MAX)");

            builder.Property(x => x.Url)
              .HasColumnName("URL")
                .HasColumnOrder(5)
                .HasColumnType("nvarchar(100)");
            
            builder.Property(x => x.Icon)
              .HasColumnName("ICON")
                .HasColumnOrder(6)
                .HasColumnType("nvarchar(50)");

            //builder.HasOne(x => x.UpperPage)
            // .WithOne(x => x.LowerPages)
            // .HasForeignKey<Page>(x => x.UpperPageId)
            // .HasConstraintName("INVOICES_ORDER")
            // .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.UpperPage)
             .WithMany(x => x.LowerPages)
             .HasForeignKey(x => x.UpperPageId)
             .HasConstraintName("UPPERPAGE_LOWERPAGE")
             .OnDelete(DeleteBehavior.NoAction);


            builder.ToTable("PAGE");
        }
    }
}
