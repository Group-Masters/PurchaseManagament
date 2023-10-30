﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Persistence.Concrete.Mappings
{
    internal class CompanyMapping : AuditableEntityMapping<Company>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("COMPANIES");

            builder.Property(x => x.Name)
                .HasColumnName("COMPANY_NAME").HasColumnType("nvarchar(50)");
            builder.Property(x => x.Adress)
              .HasColumnName("COMPANY_ADDRESS").HasColumnType("nvarchar(150)");

            builder.HasMany(x => x.CompanyStocks)
                .WithOne(x => x.Company)
                .HasForeignKey(x => x.CompanyId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(builder => builder.CompanyDepartments)
                .WithOne(x => x.Company)
                .HasForeignKey(x => x.CompanyId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
