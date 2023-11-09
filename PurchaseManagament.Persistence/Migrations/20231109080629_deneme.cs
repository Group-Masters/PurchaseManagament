using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PurchaseManagament.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class deneme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "STOCK_OPERATIONS_COMPANY_DEPARTMENT",
                table: "STOCK_OPERATIONS");

            migrationBuilder.RenameColumn(
                name: "COMPANY_DEPARTMENT_ID",
                table: "STOCK_OPERATIONS",
                newName: "RECEIVING_EMPLOYEE");

            migrationBuilder.RenameIndex(
                name: "IX_STOCK_OPERATIONS_COMPANY_DEPARTMENT_ID",
                table: "STOCK_OPERATIONS",
                newName: "IX_STOCK_OPERATIONS_RECEIVING_EMPLOYEE");

            migrationBuilder.AddForeignKey(
                name: "STOCK_OPERATIONS_RECEIVING_EMPLOYEE",
                table: "STOCK_OPERATIONS",
                column: "RECEIVING_EMPLOYEE",
                principalTable: "EMPLOYEES",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "STOCK_OPERATIONS_RECEIVING_EMPLOYEE",
                table: "STOCK_OPERATIONS");

            migrationBuilder.RenameColumn(
                name: "RECEIVING_EMPLOYEE",
                table: "STOCK_OPERATIONS",
                newName: "COMPANY_DEPARTMENT_ID");

            migrationBuilder.RenameIndex(
                name: "IX_STOCK_OPERATIONS_RECEIVING_EMPLOYEE",
                table: "STOCK_OPERATIONS",
                newName: "IX_STOCK_OPERATIONS_COMPANY_DEPARTMENT_ID");

            migrationBuilder.AddForeignKey(
                name: "STOCK_OPERATIONS_COMPANY_DEPARTMENT",
                table: "STOCK_OPERATIONS",
                column: "COMPANY_DEPARTMENT_ID",
                principalTable: "COMPANY_DEPARTMENTS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
