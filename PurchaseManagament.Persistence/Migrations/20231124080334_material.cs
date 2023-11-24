﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PurchaseManagament.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class material : Migration
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
                    NAME = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ADDRESS = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CREATE_IP = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MODIFIED_IP = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "1"),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    MANAGER_THRESHOLD = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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
                    table.PrimaryKey("PK_CURRENCIES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DEPARTMENTS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DEPARTMENT_NAME = table.Column<string>(type: "nvarchar(50)", nullable: false),
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
                    table.PrimaryKey("PK_DEPARTMENTS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MEASURING_UNIT",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(20)", nullable: false),
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
                    table.PrimaryKey("PK_MEASURING_UNIT", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ROLES",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ROLE_NAME = table.Column<string>(type: "nvarchar(50)", nullable: false),
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
                    table.PrimaryKey("PK_SUPPLIERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "COMPANY_DEPARTMENTS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COMPANY_ID = table.Column<long>(type: "bigint", nullable: false),
                    DEPARTMENT_ID = table.Column<long>(type: "bigint", nullable: false),
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
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
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
                name: "OFFERS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CURRENCY_ID = table.Column<long>(type: "BigInt", nullable: false),
                    SUPPLIER_ID = table.Column<long>(type: "BigInt", nullable: false),
                    APPROVING_EMPLOYEE_ID = table.Column<long>(type: "bigint", nullable: true),
                    ABOVE_THRESHOLD = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DETAILS = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    STATUS = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_OFFERS_SUPPLIERS_SUPPLIER_ID",
                        column: x => x.SUPPLIER_ID,
                        principalTable: "SUPPLIERS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "REQUESTS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REQUEST_EMPLOYEE_ID = table.Column<long>(type: "bigint", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STATUS = table.Column<int>(type: "int", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CREATE_IP = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MODIFIED_IP = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "1"),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    ProductId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REQUESTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_REQUESTS_PRODUCTS_ProductId",
                        column: x => x.ProductId,
                        principalTable: "PRODUCTS",
                        principalColumn: "ID");
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
                name: "INVOICES",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    STATUS = table.Column<int>(type: "int", nullable: false),
                    IMAGE_SRC = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    TRY_RATE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CREATE_IP = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MODIFIED_IP = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "1"),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    OfferId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INVOICES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_INVOICES_OFFERS_OfferId",
                        column: x => x.OfferId,
                        principalTable: "OFFERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MATERIALS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REQUEST_ID = table.Column<long>(type: "bigint", nullable: false),
                    PRODUCT_ID = table.Column<long>(type: "bigint", nullable: false),
                    DETAILS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QUANTITY = table.Column<double>(type: "float", nullable: false),
                    APPROVING_EMPLOYEE_ID = table.Column<long>(type: "bigint", nullable: true),
                    APPROVED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    STATUS = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_MATERIALS", x => x.ID);
                    table.ForeignKey(
                        name: "MATERIAL_APPROVING_EMPLOYEE",
                        column: x => x.APPROVING_EMPLOYEE_ID,
                        principalTable: "EMPLOYEES",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "MATERIAL_PRODUCT",
                        column: x => x.PRODUCT_ID,
                        principalTable: "PRODUCTS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "MATERIAL_REQUEST",
                        column: x => x.REQUEST_ID,
                        principalTable: "REQUESTS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "MATERIAL_OFFERS",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OFFER_ID = table.Column<long>(type: "bigint", nullable: false),
                    MATERIAL_ID = table.Column<long>(type: "bigint", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CREATE_IP = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MODIFIED_BY_ID = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MODIFIED_IP = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "1"),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "0"),
                    OfferedPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATERIAL_OFFERS", x => x.ID);
                    table.ForeignKey(
                        name: "MATERIAL_OFFERS_MATERIAL",
                        column: x => x.MATERIAL_ID,
                        principalTable: "MATERIALS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "MATERIAL_OFFERS_OFFER",
                        column: x => x.OFFER_ID,
                        principalTable: "OFFERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "COMPANIES",
                columns: new[] { "ID", "ADDRESS", "CREATED_BY_ID", "CREATE_DATE", "CREATE_IP", "MANAGER_THRESHOLD", "MODIFIED_BY_ID", "MODIFIED_DATE", "MODIFIED_IP", "NAME" },
                values: new object[] { 1L, "Varsayılan Adres", null, null, null, 0m, null, null, null, "Varsayılan Şirket" });

            migrationBuilder.InsertData(
                table: "CURRENCIES",
                columns: new[] { "ID", "CREATED_BY_ID", "CREATE_DATE", "CREATE_IP", "MODIFIED_BY_ID", "MODIFIED_DATE", "MODIFIED_IP", "CURRENCY_NAME" },
                values: new object[,]
                {
                    { 1L, null, null, null, null, null, null, "TRY" },
                    { 2L, null, null, null, null, null, null, "USD" },
                    { 3L, null, null, null, null, null, null, "AUD" },
                    { 4L, null, null, null, null, null, null, "DKK" },
                    { 5L, null, null, null, null, null, null, "EUR" },
                    { 6L, null, null, null, null, null, null, "GBP" },
                    { 7L, null, null, null, null, null, null, "CHF" },
                    { 8L, null, null, null, null, null, null, "SEK" },
                    { 9L, null, null, null, null, null, null, "CAD" },
                    { 10L, null, null, null, null, null, null, "KWD" },
                    { 11L, null, null, null, null, null, null, "NOK" },
                    { 12L, null, null, null, null, null, null, "SAR" },
                    { 13L, null, null, null, null, null, null, "JPY" }
                });

            migrationBuilder.InsertData(
                table: "DEPARTMENTS",
                columns: new[] { "ID", "CREATED_BY_ID", "CREATE_DATE", "CREATE_IP", "MODIFIED_BY_ID", "MODIFIED_DATE", "MODIFIED_IP", "DEPARTMENT_NAME" },
                values: new object[] { 1L, null, null, null, null, null, null, "Varsayılan Departman" });

            migrationBuilder.InsertData(
                table: "MEASURING_UNIT",
                columns: new[] { "ID", "CREATED_BY_ID", "CREATE_DATE", "CREATE_IP", "MODIFIED_BY_ID", "MODIFIED_DATE", "MODIFIED_IP", "NAME" },
                values: new object[,]
                {
                    { 1L, null, null, null, null, null, null, "Adet" },
                    { 2L, null, null, null, null, null, null, "Kilogram" },
                    { 3L, null, null, null, null, null, null, "Metre" },
                    { 4L, null, null, null, null, null, null, "Metrekare" },
                    { 5L, null, null, null, null, null, null, "Metre Küp" },
                    { 6L, null, null, null, null, null, null, "Litre" }
                });

            migrationBuilder.InsertData(
                table: "ROLES",
                columns: new[] { "ID", "CREATED_BY_ID", "CREATE_DATE", "CREATE_IP", "MODIFIED_BY_ID", "MODIFIED_DATE", "MODIFIED_IP", "ROLE_NAME" },
                values: new object[,]
                {
                    { 1L, null, null, null, null, null, null, "Admin" },
                    { 2L, null, null, null, null, null, null, "Satın Alma Sorumlusu" },
                    { 3L, null, null, null, null, null, null, "Onay" },
                    { 4L, null, null, null, null, null, null, "Talep" },
                    { 5L, null, null, null, null, null, null, "Birim Sorumlusu" },
                    { 6L, null, null, null, null, null, null, "Muhasebe" },
                    { 7L, null, null, null, null, null, null, "Genel Müdür" },
                    { 8L, null, null, null, null, null, null, "Y.K Başkanı" },
                    { 9L, null, null, null, null, null, null, "Stok Sorumlusu" },
                    { 10L, null, null, null, null, null, null, "Birim Müdürü" }
                });

            migrationBuilder.InsertData(
                table: "SUPPLIERS",
                columns: new[] { "ID", "ADDRESS", "CREATED_BY_ID", "CREATE_DATE", "CREATE_IP", "MODIFIED_BY_ID", "MODIFIED_DATE", "MODIFIED_IP", "NAME" },
                values: new object[] { 1L, "Şirket Adres", null, null, null, null, null, null, "Şirket Stok" });

            migrationBuilder.InsertData(
                table: "COMPANY_DEPARTMENTS",
                columns: new[] { "ID", "COMPANY_ID", "CREATED_BY_ID", "CREATE_DATE", "CREATE_IP", "DEPARTMENT_ID", "MODIFIED_BY_ID", "MODIFIED_DATE", "MODIFIED_IP" },
                values: new object[] { 1L, 1L, null, null, null, 1L, null, null, null });

            migrationBuilder.InsertData(
                table: "EMPLOYEES",
                columns: new[] { "ID", "BIRTH_YEAR", "COMPANY_DEPARTMENT_ID", "CREATED_BY_ID", "CREATE_DATE", "CREATE_IP", "GENDER", "ID_NUMBER", "MODIFIED_BY_ID", "MODIFIED_DATE", "MODIFIED_IP", "NAME", "SURNAME" },
                values: new object[] { 1L, "1999", 1L, null, null, null, 0, "12345678910", null, null, null, "Varsayılan", "Çalışan" });

            migrationBuilder.InsertData(
                table: "EMPLOYEE_DETAILS",
                columns: new[] { "ID", "ADDRESS", "APPROVED_CODE", "CREATED_BY_ID", "CREATE_DATE", "CREATE_IP", "EMAIL", "EMAIL_OK", "EMPLOYEE_ID", "MODIFIED_BY_ID", "MODIFIED_DATE", "MODIFIED_IP", "PASSWORD", "PHONE", "USERNAME" },
                values: new object[] { 1L, "Varsayılan Adres", "111111", null, null, null, "default@mail.com", true, 1L, null, null, null, "kVU41twDyttUL/SM7IO0vQ==", "12345678910", "Varsayılan" });

            migrationBuilder.InsertData(
                table: "EMPLOYEE_ROLES",
                columns: new[] { "ID", "CREATED_BY_ID", "CREATE_DATE", "CREATE_IP", "EMPLOYEE_ID", "MODIFIED_BY_ID", "MODIFIED_DATE", "MODIFIED_IP", "ROLE_ID" },
                values: new object[] { 1L, null, null, null, 1L, null, null, null, 1L });

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
                name: "IX_INVOICES_OfferId",
                table: "INVOICES",
                column: "OfferId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MATERIAL_OFFERS_MATERIAL_ID",
                table: "MATERIAL_OFFERS",
                column: "MATERIAL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MATERIAL_OFFERS_OFFER_ID",
                table: "MATERIAL_OFFERS",
                column: "OFFER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MATERIALS_APPROVING_EMPLOYEE_ID",
                table: "MATERIALS",
                column: "APPROVING_EMPLOYEE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MATERIALS_PRODUCT_ID",
                table: "MATERIALS",
                column: "PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MATERIALS_REQUEST_ID",
                table: "MATERIALS",
                column: "REQUEST_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OFFERS_APPROVING_EMPLOYEE_ID",
                table: "OFFERS",
                column: "APPROVING_EMPLOYEE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OFFERS_CURRENCY_ID",
                table: "OFFERS",
                column: "CURRENCY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OFFERS_SUPPLIER_ID",
                table: "OFFERS",
                column: "SUPPLIER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_MEASURING_UNIT_ID",
                table: "PRODUCTS",
                column: "MEASURING_UNIT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_REQUESTS_ProductId",
                table: "REQUESTS",
                column: "ProductId");

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
                name: "EMPLOYEE_DETAILS");

            migrationBuilder.DropTable(
                name: "EMPLOYEE_ROLES");

            migrationBuilder.DropTable(
                name: "IMG_PRODUCT");

            migrationBuilder.DropTable(
                name: "INVOICES");

            migrationBuilder.DropTable(
                name: "MATERIAL_OFFERS");

            migrationBuilder.DropTable(
                name: "STOCK_OPERATIONS");

            migrationBuilder.DropTable(
                name: "ROLES");

            migrationBuilder.DropTable(
                name: "MATERIALS");

            migrationBuilder.DropTable(
                name: "OFFERS");

            migrationBuilder.DropTable(
                name: "COMPANY_STOCK");

            migrationBuilder.DropTable(
                name: "REQUESTS");

            migrationBuilder.DropTable(
                name: "CURRENCIES");

            migrationBuilder.DropTable(
                name: "SUPPLIERS");

            migrationBuilder.DropTable(
                name: "PRODUCTS");

            migrationBuilder.DropTable(
                name: "EMPLOYEES");

            migrationBuilder.DropTable(
                name: "MEASURING_UNIT");

            migrationBuilder.DropTable(
                name: "COMPANY_DEPARTMENTS");

            migrationBuilder.DropTable(
                name: "COMPANIES");

            migrationBuilder.DropTable(
                name: "DEPARTMENTS");
        }
    }
}
