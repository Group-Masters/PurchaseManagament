using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PurchaseManagament.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class cumcunHasan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notification",
                table: "STOCK_OPERATIONS",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notification",
                table: "STOCK_OPERATIONS");
        }
    }
}
