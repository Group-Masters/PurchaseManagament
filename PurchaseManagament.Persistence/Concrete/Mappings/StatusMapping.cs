using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseManagament.Domain.Entities;
using System.Resources;

namespace PurchaseManagament.Persistence.Concrete.Mappings
{
    public class StatusMapping : AuditableEntityMapping<Status>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("STATUS");
        }
    }
}
