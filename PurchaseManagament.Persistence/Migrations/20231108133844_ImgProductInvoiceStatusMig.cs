using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PurchaseManagament.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ImgProductInvoiceStatusMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "STATUS",
                table: "INVOICES",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("Relational:ColumnOrder", 4);

            migrationBuilder.CreateTable(
                name: "IMG_PRODUCT",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRODUCT_ID = table.Column<long>(type: "BigInt", nullable: false),
                    IMAGE_SRC = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CREATE_IP = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MODIFIED_IP = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "1"),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IMG_PRODUCT", x => x.ID);
                    table.ForeignKey(
                        name: "PRODUCT_IMG",
                        column: x => x.PRODUCT_ID,
                        principalTable: "PRODUCTS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_IMG_PRODUCT_PRODUCT_ID",
                table: "IMG_PRODUCT",
                column: "PRODUCT_ID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IMG_PRODUCT");

            migrationBuilder.DropColumn(
                name: "STATUS",
                table: "INVOICES");
        }
    }
}
