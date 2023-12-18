using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PurchaseManagament.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TeslimSonrasi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PAGE",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PAGE_NAME = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    LOWER_PAGES = table.Column<long>(type: "bigint", nullable: true),
                    CONTENT = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(100)", nullable: true),
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
                    table.PrimaryKey("PK_PAGE", x => x.ID);
                    table.ForeignKey(
                        name: "UPPERPAGE_LOWERPAGE",
                        column: x => x.LOWER_PAGES,
                        principalTable: "PAGE",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PAGE_ROLE",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PAGE_ID = table.Column<long>(type: "bigint", nullable: false),
                    ROLE_ID = table.Column<long>(type: "bigint", nullable: false),
                    DELETING = table.Column<bool>(type: "bit", nullable: false),
                    UPDATING = table.Column<bool>(type: "bit", nullable: false),
                    CREATING = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_PAGE_ROLE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PAGE_ROLE_PAGE_PAGE_ID",
                        column: x => x.PAGE_ID,
                        principalTable: "PAGE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PAGE_ROLE_ROLES_ROLE_ID",
                        column: x => x.ROLE_ID,
                        principalTable: "ROLES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PAGE_LOWER_PAGES",
                table: "PAGE",
                column: "LOWER_PAGES");

            migrationBuilder.CreateIndex(
                name: "IX_PAGE_ROLE_PAGE_ID",
                table: "PAGE_ROLE",
                column: "PAGE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PAGE_ROLE_ROLE_ID",
                table: "PAGE_ROLE",
                column: "ROLE_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PAGE_ROLE");

            migrationBuilder.DropTable(
                name: "PAGE");
        }
    }
}
