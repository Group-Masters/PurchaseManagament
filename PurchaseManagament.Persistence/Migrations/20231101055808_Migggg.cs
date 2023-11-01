using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PurchaseManagament.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Migggg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "COMPANIES",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COMPANY_NAME = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    COMPANY_ADDRESS = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    IS_ACTIVE = table.Column<string>(type: "nvarchar(10)", nullable: true, defaultValueSql: "0"),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATE_IP = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    CREATED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MODIFIED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MODIFIED_IP = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPANIES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CURRENCIES",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CURRENCY_NAME = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    CURRENCY_Rate = table.Column<double>(type: "float", nullable: false),
                    IS_ACTIVE = table.Column<string>(type: "nvarchar(10)", nullable: true, defaultValueSql: "0"),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATE_IP = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    CREATED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MODIFIED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MODIFIED_IP = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CURRENCIES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DEPATMENTS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DEPARTMENT_NAME = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    IS_ACTIVE = table.Column<string>(type: "nvarchar(10)", nullable: true, defaultValueSql: "0"),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATE_IP = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    CREATED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MODIFIED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MODIFIED_IP = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEPATMENTS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MEASURING_UNIT",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IS_ACTIVE = table.Column<string>(type: "nvarchar(10)", nullable: true, defaultValueSql: "0"),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATE_IP = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    CREATED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MODIFIED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MODIFIED_IP = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MEASURING_UNIT", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ROLES",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ROLE_NAME = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    IS_ACTIVE = table.Column<string>(type: "nvarchar(10)", nullable: true, defaultValueSql: "0"),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATE_IP = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    CREATED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MODIFIED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MODIFIED_IP = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SUPPLIERS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    SUPLIER_ADDRESS = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    IS_ACTIVE = table.Column<string>(type: "nvarchar(10)", nullable: true, defaultValueSql: "0"),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATE_IP = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    CREATED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MODIFIED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MODIFIED_IP = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUPPLIERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "COMPANY_DEPARTMENTS",
                columns: table => new
                {
                    COMPANY_ID = table.Column<long>(type: "bigint", nullable: false),
                    DEPARTMENT_ID = table.Column<long>(type: "bigint", nullable: false),
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IS_ACTIVE = table.Column<string>(type: "nvarchar(10)", nullable: true, defaultValueSql: "0"),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATE_IP = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    CREATED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MODIFIED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MODIFIED_IP = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPANY_DEPARTMENTS", x => x.ID);
                    table.ForeignKey(
                        name: "COMPANY_DEPARTMENT_COMPANIES",
                        column: x => x.COMPANY_ID,
                        principalTable: "COMPANIES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "COMPANY_DEPARTMENT_DEPARTMENTS",
                        column: x => x.DEPARTMENT_ID,
                        principalTable: "DEPATMENTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTS",
                columns: table => new
                {
                    MEASURING_UNIT_ID = table.Column<long>(type: "bigint", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IS_ACTIVE = table.Column<string>(type: "nvarchar(10)", nullable: true, defaultValueSql: "0"),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATE_IP = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    CREATED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MODIFIED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MODIFIED_IP = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTS", x => x.ID);
                    table.ForeignKey(
                        name: "PRODUCT_MEASURING_UNITS",
                        column: x => x.MEASURING_UNIT_ID,
                        principalTable: "MEASURING_UNIT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEES",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COMPANY_DEPARTMENT_ID = table.Column<long>(type: "bigint", nullable: false),
                    EMPLOYEE_NAME = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    EMPLOYEE_SURNAME = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    EMPLOYEE_ID_NUMBER = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BIRTH_YEAR = table.Column<string>(type: "nvarchar(4)", nullable: false),
                    GENDER = table.Column<int>(type: "int", nullable: false),
                    IS_ACTIVE = table.Column<string>(type: "nvarchar(10)", nullable: true, defaultValueSql: "0"),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATE_IP = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    CREATED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MODIFIED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MODIFIED_IP = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EMPLOYEES_COMPANY_DEPARTMENTS_COMPANY_DEPARTMENT_ID",
                        column: x => x.COMPANY_DEPARTMENT_ID,
                        principalTable: "COMPANY_DEPARTMENTS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "COMPANY_STOCK",
                columns: table => new
                {
                    COMPANY_ID = table.Column<long>(type: "bigint", nullable: false),
                    PRODUCT_ID = table.Column<long>(type: "bigint", nullable: false),
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QUANTİTY = table.Column<double>(type: "float", nullable: false),
                    IS_ACTIVE = table.Column<string>(type: "nvarchar(10)", nullable: true, defaultValueSql: "0"),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATE_IP = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    CREATED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MODIFIED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MODIFIED_IP = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPANY_STOCK", x => x.ID);
                    table.ForeignKey(
                        name: "COMPANY_DEPARTMENT_PRODUCTS",
                        column: x => x.PRODUCT_ID,
                        principalTable: "PRODUCTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "COMPANY_STOCK_COMPANIES",
                        column: x => x.COMPANY_ID,
                        principalTable: "COMPANIES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEE_DETAILS",
                columns: table => new
                {
                    EMPLOYEE_ID = table.Column<long>(type: "bigint", nullable: false),
                    EmailOk = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    ApprovedCode = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USERNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ADDRESS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMPLOYEE_PHONE = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    EMPLOYEE_EMAIL = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    EMPLOYEE_PASSWORD = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    IS_ACTIVE = table.Column<string>(type: "nvarchar(10)", nullable: true, defaultValueSql: "0"),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATE_IP = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    CREATED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MODIFIED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MODIFIED_IP = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEE_DETAILS", x => x.ID);
                    table.ForeignKey(
                        name: "EMPLOYEE_DETAIL",
                        column: x => x.EMPLOYEE_ID,
                        principalTable: "EMPLOYEES",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEE_ROLES",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EMPLOYEE_ID = table.Column<long>(type: "bigint", nullable: false),
                    ROLE_ID = table.Column<long>(type: "bigint", nullable: false),
                    IS_ACTIVE = table.Column<string>(type: "nvarchar(10)", nullable: true, defaultValueSql: "0"),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATE_IP = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    CREATED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MODIFIED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MODIFIED_IP = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEE_ROLES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EMPLOYEE_ROLES_EMPLOYEES_EMPLOYEE_ID",
                        column: x => x.EMPLOYEE_ID,
                        principalTable: "EMPLOYEES",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_EMPLOYEE_ROLES_ROLES_ROLE_ID",
                        column: x => x.ROLE_ID,
                        principalTable: "ROLES",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    PRODUCT_ID = table.Column<long>(type: "bigint", nullable: false),
                    APPROVING_EMPLOYEE_ID = table.Column<long>(type: "bigint", nullable: false),
                    REQUEST_EMPLOYEE_ID = table.Column<long>(type: "bigint", nullable: false),
                    DETAILS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QUANTITY = table.Column<double>(type: "float", nullable: false),
                    STATUS = table.Column<int>(type: "int", nullable: false),
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IS_ACTIVE = table.Column<string>(type: "nvarchar(10)", nullable: true, defaultValueSql: "0"),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATE_IP = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    CREATED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MODIFIED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MODIFIED_IP = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.ID);
                    table.ForeignKey(
                        name: "REQUEST_APPROVING_EMPLOYEE",
                        column: x => x.APPROVING_EMPLOYEE_ID,
                        principalTable: "EMPLOYEES",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "REQUEST_PRODUCTS",
                        column: x => x.PRODUCT_ID,
                        principalTable: "PRODUCTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "REQUEST_REQUEST_EMPLOYEE",
                        column: x => x.REQUEST_EMPLOYEE_ID,
                        principalTable: "EMPLOYEES",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "STOCK_OPERATIONS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COMPANYSTOCK_ID = table.Column<long>(type: "bigint", nullable: false),
                    RECEIVER_EMPLOYEE_ID = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    QUANTITY = table.Column<double>(type: "float", nullable: false),
                    IS_ACTIVE = table.Column<string>(type: "nvarchar(10)", nullable: true, defaultValueSql: "0"),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATE_IP = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    CREATED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MODIFIED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MODIFIED_IP = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STOCK_OPERATIONS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_STOCK_OPERATIONS_COMPANY_STOCK_COMPANYSTOCK_ID",
                        column: x => x.COMPANYSTOCK_ID,
                        principalTable: "COMPANY_STOCK",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_STOCK_OPERATIONS_EMPLOYEES_RECEIVER_EMPLOYEE_ID",
                        column: x => x.RECEIVER_EMPLOYEE_ID,
                        principalTable: "EMPLOYEES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_STOCK_OPERATIONS_PRODUCTS_ProductId",
                        column: x => x.ProductId,
                        principalTable: "PRODUCTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OFFERS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CURRENCY_ID = table.Column<long>(type: "BigInt", nullable: false),
                    SUPLIER_ID = table.Column<long>(type: "BigInt", nullable: false),
                    REQUEST_ID = table.Column<long>(type: "BigInt", nullable: false),
                    ApprovingEmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    OFFERED_PRICE = table.Column<long>(type: "BigInt", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STATUS = table.Column<int>(type: "int", nullable: false),
                    IS_ACTIVE = table.Column<string>(type: "nvarchar(10)", nullable: true, defaultValueSql: "0"),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATE_IP = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    CREATED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MODIFIED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MODIFIED_IP = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OFFERS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OFFERS_CURRENCIES_CURRENCY_ID",
                        column: x => x.CURRENCY_ID,
                        principalTable: "CURRENCIES",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_OFFERS_EMPLOYEES_ApprovingEmployeeId",
                        column: x => x.ApprovingEmployeeId,
                        principalTable: "EMPLOYEES",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_OFFERS_Requests_REQUEST_ID",
                        column: x => x.REQUEST_ID,
                        principalTable: "Requests",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_OFFERS_SUPPLIERS_SUPLIER_ID",
                        column: x => x.SUPLIER_ID,
                        principalTable: "SUPPLIERS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "INVOICES",
                columns: table => new
                {
                    OfferId = table.Column<long>(type: "bigint", nullable: false),
                    UUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IS_ACTIVE = table.Column<string>(type: "nvarchar(10)", nullable: true, defaultValueSql: "0"),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATE_IP = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    CREATED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MODIFIED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MODIFIED_IP = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INVOICES", x => x.ID);
                    table.ForeignKey(
                        name: "INVOICES_ORDER",
                        column: x => x.OfferId,
                        principalTable: "OFFERS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_COMPANY_DEPARTMENTS_COMPANY_ID",
                table: "COMPANY_DEPARTMENTS",
                column: "COMPANY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_COMPANY_DEPARTMENTS_DEPARTMENT_ID",
                table: "COMPANY_DEPARTMENTS",
                column: "DEPARTMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_COMPANY_STOCK_COMPANY_ID",
                table: "COMPANY_STOCK",
                column: "COMPANY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_COMPANY_STOCK_PRODUCT_ID",
                table: "COMPANY_STOCK",
                column: "PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEE_DETAILS_EMPLOYEE_ID",
                table: "EMPLOYEE_DETAILS",
                column: "EMPLOYEE_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEE_ROLES_EMPLOYEE_ID",
                table: "EMPLOYEE_ROLES",
                column: "EMPLOYEE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEE_ROLES_ROLE_ID",
                table: "EMPLOYEE_ROLES",
                column: "ROLE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEES_COMPANY_DEPARTMENT_ID",
                table: "EMPLOYEES",
                column: "COMPANY_DEPARTMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INVOICES_OfferId",
                table: "INVOICES",
                column: "OfferId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OFFERS_ApprovingEmployeeId",
                table: "OFFERS",
                column: "ApprovingEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OFFERS_CURRENCY_ID",
                table: "OFFERS",
                column: "CURRENCY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OFFERS_REQUEST_ID",
                table: "OFFERS",
                column: "REQUEST_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OFFERS_SUPLIER_ID",
                table: "OFFERS",
                column: "SUPLIER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_MEASURING_UNIT_ID",
                table: "PRODUCTS",
                column: "MEASURING_UNIT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_APPROVING_EMPLOYEE_ID",
                table: "Requests",
                column: "APPROVING_EMPLOYEE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_PRODUCT_ID",
                table: "Requests",
                column: "PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_REQUEST_EMPLOYEE_ID",
                table: "Requests",
                column: "REQUEST_EMPLOYEE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_STOCK_OPERATIONS_COMPANYSTOCK_ID",
                table: "STOCK_OPERATIONS",
                column: "COMPANYSTOCK_ID");

            migrationBuilder.CreateIndex(
                name: "IX_STOCK_OPERATIONS_ProductId",
                table: "STOCK_OPERATIONS",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_STOCK_OPERATIONS_RECEIVER_EMPLOYEE_ID",
                table: "STOCK_OPERATIONS",
                column: "RECEIVER_EMPLOYEE_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EMPLOYEE_DETAILS");

            migrationBuilder.DropTable(
                name: "EMPLOYEE_ROLES");

            migrationBuilder.DropTable(
                name: "INVOICES");

            migrationBuilder.DropTable(
                name: "STOCK_OPERATIONS");

            migrationBuilder.DropTable(
                name: "ROLES");

            migrationBuilder.DropTable(
                name: "OFFERS");

            migrationBuilder.DropTable(
                name: "COMPANY_STOCK");

            migrationBuilder.DropTable(
                name: "CURRENCIES");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "SUPPLIERS");

            migrationBuilder.DropTable(
                name: "EMPLOYEES");

            migrationBuilder.DropTable(
                name: "PRODUCTS");

            migrationBuilder.DropTable(
                name: "COMPANY_DEPARTMENTS");

            migrationBuilder.DropTable(
                name: "MEASURING_UNIT");

            migrationBuilder.DropTable(
                name: "COMPANIES");

            migrationBuilder.DropTable(
                name: "DEPATMENTS");
        }
    }
}
