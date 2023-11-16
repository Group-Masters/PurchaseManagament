using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PurchaseManagament.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InvoiceCurrencyCompanyChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CURRENCY_RATE",
                table: "CURRENCIES");

            migrationBuilder.AddColumn<string>(
                name: "IMAGE_SRC",
                table: "INVOICES",
                type: "nvarchar(150)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 5);

            migrationBuilder.AddColumn<decimal>(
                name: "TRY_RATE",
                table: "INVOICES",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m)
                .Annotation("Relational:ColumnOrder", 6);

            migrationBuilder.AddColumn<decimal>(
                name: "MANAGER_THRESHOLD",
                table: "COMPANIES",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IMAGE_SRC",
                table: "INVOICES");

            migrationBuilder.DropColumn(
                name: "TRY_RATE",
                table: "INVOICES");

            migrationBuilder.DropColumn(
                name: "MANAGER_THRESHOLD",
                table: "COMPANIES");

            migrationBuilder.AddColumn<double>(
                name: "CURRENCY_RATE",
                table: "CURRENCIES",
                type: "float",
                nullable: false,
                defaultValue: 0.0)
                .Annotation("Relational:ColumnOrder", 3);
        }
    }
}
