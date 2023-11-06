using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Persistence.Concrete.Mappings
{
    public class LoggedMapping : IEntityTypeConfiguration<logged>
    {
        public void Configure(EntityTypeBuilder<logged> builder)
        {
            builder.ToTable("LOGGED"); // Veritabanında kullanılacak tablo adını belirler

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnName("ID")
                .IsRequired();

            builder.Property(e => e.EmployeeId)
                .HasColumnName("EMPLOYEE_ID")
                .IsRequired();

            builder.Property(e => e.DepartmentId)
                .HasColumnName("DEPARTMENT_ID")
                .IsRequired();

            builder.Property(e => e.CompanyId)
                .HasColumnName("COMPANY_ID")
                .IsRequired();

            builder.Property(e => e.detail)
                .HasColumnName("DETAIL")
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder.Property(e => e.Date)
                .HasColumnName("LOG_DATE")
                .IsRequired();
        }
    }
}
