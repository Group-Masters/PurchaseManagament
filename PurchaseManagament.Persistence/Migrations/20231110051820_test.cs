using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PurchaseManagament.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AUDIT_META_DATAS",
                columns: table => new
                {
                    READABLE_PRIMARY_KEY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TABLE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DISPLAY_NAME = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HashPrimaryKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUDIT_META_DATAS", x => new { x.HashPrimaryKey, x.DISPLAY_NAME });
                });

            migrationBuilder.CreateTable(
                name: "COMPANIES",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ADDRESS = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "1"),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
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
                    CURRENCY_NAME = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CURRENCY_RATE = table.Column<double>(type: "float", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "1"),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CURRENCIES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DEPARTMENTS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DEPARTMENT_NAME = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "1"),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEPARTMENTS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MEASURING_UNIT",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "1"),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
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
                    ROLE_NAME = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "1"),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    NAME = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ADDRESS = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "1"),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUPPLIERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AUDITS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OLD_VALUES = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NEW_VALUES = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATE_TIME = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ENTITY_STATE = table.Column<int>(type: "int", nullable: false),
                    USER_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USER_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditMetaDataHashPrimaryKey = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AuditMetaDataDisplayName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUDITS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AUDITS_AUDIT_META_DATAS_AuditMetaDataHashPrimaryKey_AuditMetaDataDisplayName",
                        columns: x => new { x.AuditMetaDataHashPrimaryKey, x.AuditMetaDataDisplayName },
                        principalTable: "AUDIT_META_DATAS",
                        principalColumns: new[] { "HashPrimaryKey", "DISPLAY_NAME" });
                });

            migrationBuilder.CreateTable(
                name: "COMPANY_DEPARTMENTS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COMPANY_ID = table.Column<long>(type: "bigint", nullable: false),
                    DEPARTMENT_ID = table.Column<long>(type: "bigint", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "1"),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
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
                        principalTable: "DEPARTMENTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MEASURING_UNIT_ID = table.Column<long>(type: "bigint", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "1"),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
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
                    NAME = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    SURNAME = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    ID_NUMBER = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BIRTH_YEAR = table.Column<string>(type: "nvarchar(4)", nullable: false),
                    GENDER = table.Column<int>(type: "int", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "1"),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
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
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COMPANY_ID = table.Column<long>(type: "bigint", nullable: false),
                    PRODUCT_ID = table.Column<long>(type: "bigint", nullable: false),
                    QUANTITY = table.Column<double>(type: "float", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "1"),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
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
                name: "IMG_PRODUCT",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRODUCT_ID = table.Column<long>(type: "BigInt", nullable: false),
                    IMAGE_SRC = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    CREATED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "EMPLOYEE_DETAILS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EMPLOYEE_ID = table.Column<long>(type: "bigint", nullable: false),
                    USERNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ADDRESS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    PASSWORD = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    PHONE = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    EMAIL_OK = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    APPROVED_CODE = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "1"),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
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
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "1"),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "REQUESTS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRODUCT_ID = table.Column<long>(type: "bigint", nullable: false),
                    APPROVING_EMPLOYEE_ID = table.Column<long>(type: "bigint", nullable: true),
                    REQUEST_EMPLOYEE_ID = table.Column<long>(type: "bigint", nullable: false),
                    DETAILS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QUANTITY = table.Column<double>(type: "float", nullable: false),
                    STATUS = table.Column<int>(type: "int", nullable: false),
                    CREATED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "1"),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REQUESTS", x => x.ID);
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
                    COMPANY_STOCK_ID = table.Column<long>(type: "bigint", nullable: false),
                    RECEIVING_EMPLOYEE = table.Column<long>(type: "bigint", nullable: false),
                    QUANTITY = table.Column<double>(type: "float", nullable: false),
                    CREATED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "1"),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STOCK_OPERATIONS", x => x.ID);
                    table.ForeignKey(
                        name: "STOCK_OPERATIONS_COMPANY_STOCK",
                        column: x => x.COMPANY_STOCK_ID,
                        principalTable: "COMPANY_STOCK",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "STOCK_OPERATIONS_RECEIVING_EMPLOYEE",
                        column: x => x.RECEIVING_EMPLOYEE,
                        principalTable: "EMPLOYEES",
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
                    SUPPLIER_ID = table.Column<long>(type: "BigInt", nullable: false),
                    REQUEST_ID = table.Column<long>(type: "BigInt", nullable: false),
                    APPROVING_EMPLOYEE_ID = table.Column<long>(type: "bigint", nullable: true),
                    OFFERED_PRICE = table.Column<long>(type: "BigInt", nullable: false),
                    DETAILS = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    STATUS = table.Column<int>(type: "int", nullable: false),
                    CREATED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "1"),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
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
                        name: "FK_OFFERS_EMPLOYEES_APPROVING_EMPLOYEE_ID",
                        column: x => x.APPROVING_EMPLOYEE_ID,
                        principalTable: "EMPLOYEES",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_OFFERS_REQUESTS_REQUEST_ID",
                        column: x => x.REQUEST_ID,
                        principalTable: "REQUESTS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_OFFERS_SUPPLIERS_SUPPLIER_ID",
                        column: x => x.SUPPLIER_ID,
                        principalTable: "SUPPLIERS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "INVOICES",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OFFER_ID = table.Column<long>(type: "bigint", nullable: false),
                    UUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    STATUS = table.Column<int>(type: "int", nullable: false),
                    CREATED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "1"),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INVOICES", x => x.ID);
                    table.ForeignKey(
                        name: "INVOICES_ORDER",
                        column: x => x.OFFER_ID,
                        principalTable: "OFFERS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AUDITS_AuditMetaDataHashPrimaryKey_AuditMetaDataDisplayName",
                table: "AUDITS",
                columns: new[] { "AuditMetaDataHashPrimaryKey", "AuditMetaDataDisplayName" });

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
                name: "IX_IMG_PRODUCT_PRODUCT_ID",
                table: "IMG_PRODUCT",
                column: "PRODUCT_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_INVOICES_OFFER_ID",
                table: "INVOICES",
                column: "OFFER_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OFFERS_APPROVING_EMPLOYEE_ID",
                table: "OFFERS",
                column: "APPROVING_EMPLOYEE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OFFERS_CURRENCY_ID",
                table: "OFFERS",
                column: "CURRENCY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OFFERS_REQUEST_ID",
                table: "OFFERS",
                column: "REQUEST_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OFFERS_SUPPLIER_ID",
                table: "OFFERS",
                column: "SUPPLIER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_MEASURING_UNIT_ID",
                table: "PRODUCTS",
                column: "MEASURING_UNIT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_REQUESTS_APPROVING_EMPLOYEE_ID",
                table: "REQUESTS",
                column: "APPROVING_EMPLOYEE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_REQUESTS_PRODUCT_ID",
                table: "REQUESTS",
                column: "PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_REQUESTS_REQUEST_EMPLOYEE_ID",
                table: "REQUESTS",
                column: "REQUEST_EMPLOYEE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_STOCK_OPERATIONS_COMPANY_STOCK_ID",
                table: "STOCK_OPERATIONS",
                column: "COMPANY_STOCK_ID");

            migrationBuilder.CreateIndex(
                name: "IX_STOCK_OPERATIONS_RECEIVING_EMPLOYEE",
                table: "STOCK_OPERATIONS",
                column: "RECEIVING_EMPLOYEE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AUDITS");

            migrationBuilder.DropTable(
                name: "EMPLOYEE_DETAILS");

            migrationBuilder.DropTable(
                name: "EMPLOYEE_ROLES");

            migrationBuilder.DropTable(
                name: "IMG_PRODUCT");

            migrationBuilder.DropTable(
                name: "INVOICES");

            migrationBuilder.DropTable(
                name: "STOCK_OPERATIONS");

            migrationBuilder.DropTable(
                name: "AUDIT_META_DATAS");

            migrationBuilder.DropTable(
                name: "ROLES");

            migrationBuilder.DropTable(
                name: "OFFERS");

            migrationBuilder.DropTable(
                name: "COMPANY_STOCK");

            migrationBuilder.DropTable(
                name: "CURRENCIES");

            migrationBuilder.DropTable(
                name: "REQUESTS");

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
                name: "DEPARTMENTS");
        }
    }
}
