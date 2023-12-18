using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PurchaseManagament.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class pageMappingUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LOWER_PAGES",
                table: "PAGE",
                newName: "UPPPER_PAGE_ID");

            migrationBuilder.RenameIndex(
                name: "IX_PAGE_LOWER_PAGES",
                table: "PAGE",
                newName: "IX_PAGE_UPPPER_PAGE_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UPPPER_PAGE_ID",
                table: "PAGE",
                newName: "LOWER_PAGES");

            migrationBuilder.RenameIndex(
                name: "IX_PAGE_UPPPER_PAGE_ID",
                table: "PAGE",
                newName: "IX_PAGE_LOWER_PAGES");
        }
    }
}
