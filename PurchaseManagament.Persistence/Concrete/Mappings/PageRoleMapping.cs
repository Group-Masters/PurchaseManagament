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
    public class PageRoleMapping : AuditableEntityMapping<PageRole>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<PageRole> builder)
        {
            builder.Property(x => x.PageId)
                .HasColumnName("PAGE_ID")
                .HasColumnOrder(2);

            builder.Property(x => x.RoleId)
              .HasColumnName("ROLE_ID")
              .HasColumnOrder(3);

            builder.Property(x => x.Deleting)
              .HasColumnName("DELETING")
                .HasColumnOrder(4)
                .HasColumnType("bit");

            builder.Property(x => x.Updating)
              .HasColumnName("UPDATING")
                .HasColumnOrder(5)
                .HasColumnType("bit");

            builder.Property(x => x.Creating)
              .HasColumnName("CREATING")
                .HasColumnOrder(6)
            .HasColumnType("bit");


            builder.HasOne(x => x.Role)
                .WithMany(r => r.PageRoles)
                .HasForeignKey(pr => pr.RoleId);


            


            builder.ToTable("PAGE_ROLE");
        }
    }
}
