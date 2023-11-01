using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PurchaseManagament.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig1907 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IS_ACTIVE",
                table: "SUPPLIERS",
                type: "bit",
                nullable: true,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<bool>(
                name: "IS_ACTIVE",
                table: "STOCK_OPERATIONS",
                type: "bit",
                nullable: true,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<bool>(
                name: "IS_ACTIVE",
                table: "ROLES",
                type: "bit",
                nullable: true,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<bool>(
                name: "IS_ACTIVE",
                table: "Requests",
                type: "bit",
                nullable: true,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<bool>(
                name: "IS_ACTIVE",
                table: "PRODUCTS",
                type: "bit",
                nullable: true,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<bool>(
                name: "IS_ACTIVE",
                table: "OFFERS",
                type: "bit",
                nullable: true,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<bool>(
                name: "IS_ACTIVE",
                table: "MEASURING_UNIT",
                type: "bit",
                nullable: true,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<bool>(
                name: "IS_ACTIVE",
                table: "INVOICES",
                type: "bit",
                nullable: true,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<bool>(
                name: "IS_ACTIVE",
                table: "EMPLOYEES",
                type: "bit",
                nullable: true,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<bool>(
                name: "IS_ACTIVE",
                table: "EMPLOYEE_ROLES",
                type: "bit",
                nullable: true,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<bool>(
                name: "IS_ACTIVE",
                table: "EMPLOYEE_DETAILS",
                type: "bit",
                nullable: true,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<bool>(
                name: "IS_ACTIVE",
                table: "DEPATMENTS",
                type: "bit",
                nullable: true,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<bool>(
                name: "IS_ACTIVE",
                table: "CURRENCIES",
                type: "bit",
                nullable: true,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<bool>(
                name: "IS_ACTIVE",
                table: "COMPANY_STOCK",
                type: "bit",
                nullable: true,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<bool>(
                name: "IS_ACTIVE",
                table: "COMPANY_DEPARTMENTS",
                type: "bit",
                nullable: true,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValueSql: "0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IS_ACTIVE",
                table: "SUPPLIERS",
                type: "bit",
                nullable: true,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<bool>(
                name: "IS_ACTIVE",
                table: "STOCK_OPERATIONS",
                type: "bit",
                nullable: true,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<bool>(
                name: "IS_ACTIVE",
                table: "ROLES",
                type: "bit",
                nullable: true,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<bool>(
                name: "IS_ACTIVE",
                table: "Requests",
                type: "bit",
                nullable: true,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<bool>(
                name: "IS_ACTIVE",
                table: "PRODUCTS",
                type: "bit",
                nullable: true,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<bool>(
                name: "IS_ACTIVE",
                table: "OFFERS",
                type: "bit",
                nullable: true,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<bool>(
                name: "IS_ACTIVE",
                table: "MEASURING_UNIT",
                type: "bit",
                nullable: true,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<bool>(
                name: "IS_ACTIVE",
                table: "INVOICES",
                type: "bit",
                nullable: true,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<bool>(
                name: "IS_ACTIVE",
                table: "EMPLOYEES",
                type: "bit",
                nullable: true,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<bool>(
                name: "IS_ACTIVE",
                table: "EMPLOYEE_ROLES",
                type: "bit",
                nullable: true,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<bool>(
                name: "IS_ACTIVE",
                table: "EMPLOYEE_DETAILS",
                type: "bit",
                nullable: true,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<bool>(
                name: "IS_ACTIVE",
                table: "DEPATMENTS",
                type: "bit",
                nullable: true,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<bool>(
                name: "IS_ACTIVE",
                table: "CURRENCIES",
                type: "bit",
                nullable: true,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<bool>(
                name: "IS_ACTIVE",
                table: "COMPANY_STOCK",
                type: "bit",
                nullable: true,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<bool>(
                name: "IS_ACTIVE",
                table: "COMPANY_DEPARTMENTS",
                type: "bit",
                nullable: true,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValueSql: "1");
        }
    }
}
