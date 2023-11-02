using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PurchaseManagament.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migDegisikHaller : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OFFERS_EMPLOYEES_ApprovingEmployeeId",
                table: "OFFERS");

            migrationBuilder.RenameColumn(
                name: "ApprovingEmployeeId",
                table: "OFFERS",
                newName: "APPROVING_EMPLOYEE_ID");

            migrationBuilder.RenameIndex(
                name: "IX_OFFERS_ApprovingEmployeeId",
                table: "OFFERS",
                newName: "IX_OFFERS_APPROVING_EMPLOYEE_ID");

            migrationBuilder.AlterColumn<long>(
                name: "APPROVING_EMPLOYEE_ID",
                table: "OFFERS",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_OFFERS_EMPLOYEES_APPROVING_EMPLOYEE_ID",
                table: "OFFERS",
                column: "APPROVING_EMPLOYEE_ID",
                principalTable: "EMPLOYEES",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OFFERS_EMPLOYEES_APPROVING_EMPLOYEE_ID",
                table: "OFFERS");

            migrationBuilder.RenameColumn(
                name: "APPROVING_EMPLOYEE_ID",
                table: "OFFERS",
                newName: "ApprovingEmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_OFFERS_APPROVING_EMPLOYEE_ID",
                table: "OFFERS",
                newName: "IX_OFFERS_ApprovingEmployeeId");

            migrationBuilder.AlterColumn<long>(
                name: "ApprovingEmployeeId",
                table: "OFFERS",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OFFERS_EMPLOYEES_ApprovingEmployeeId",
                table: "OFFERS",
                column: "ApprovingEmployeeId",
                principalTable: "EMPLOYEES",
                principalColumn: "ID");
        }
    }
}
