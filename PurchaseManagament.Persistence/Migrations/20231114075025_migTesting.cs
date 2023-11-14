using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PurchaseManagament.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migTesting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "PRODUCT_IMG",
                table: "IMG_PRODUCT");

            migrationBuilder.AddForeignKey(
                name: "PRODUCT_IMG",
                table: "IMG_PRODUCT",
                column: "PRODUCT_ID",
                principalTable: "PRODUCTS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "PRODUCT_IMG",
                table: "IMG_PRODUCT");

            migrationBuilder.AddForeignKey(
                name: "PRODUCT_IMG",
                table: "IMG_PRODUCT",
                column: "PRODUCT_ID",
                principalTable: "PRODUCTS",
                principalColumn: "ID");
        }
    }
}
