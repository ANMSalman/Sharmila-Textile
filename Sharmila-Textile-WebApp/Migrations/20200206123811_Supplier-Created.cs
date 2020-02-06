using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sharmila_Textile_WebApp.Migrations
{
    public partial class SupplierCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "STAFF_NAME",
                table: "STAFF",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CUSTOMER_ATTACHMENT",
                columns: table => new
                {
                    ATTACHMENT_ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ATTACHMENT_NAME = table.Column<string>(type: "varchar(max)", nullable: true),
                    ATTACHMENT_PATH = table.Column<string>(type: "varchar(max)", nullable: true),
                    CUSTOMER_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMER_ATTACHMENT", x => x.ATTACHMENT_ID);
                    table.ForeignKey(
                        name: "FK_CUSTOMER_ATTACHMENT_CUSTOMER_CUSTOMER_ID",
                        column: x => x.CUSTOMER_ID,
                        principalTable: "CUSTOMER",
                        principalColumn: "CUSTOMER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SUPPLIER",
                columns: table => new
                {
                    SUPPLIER_ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SUPPLIER_NAME = table.Column<string>(type: "varchar(50)", nullable: true),
                    ADDRESS = table.Column<string>(type: "varchar(max)", nullable: true),
                    LANDLINE = table.Column<string>(type: "nchar(10)", nullable: true),
                    MOBILE = table.Column<string>(type: "nchar(10)", nullable: true),
                    OPENING_BALANCE = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CURRENT_BALANCE = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    CREATED_BY = table.Column<long>(nullable: false),
                    CURRENT_STATUS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUPPLIER", x => x.SUPPLIER_ID);
                    table.ForeignKey(
                        name: "FK_SUPPLIER_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "USER",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SUPPLIER_ATTACHMENT",
                columns: table => new
                {
                    ATTACHMENT_ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ATTACHMENT_NAME = table.Column<string>(type: "varchar(max)", nullable: true),
                    ATTACHMENT_PATH = table.Column<string>(type: "varchar(max)", nullable: true),
                    SUPPLIER_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUPPLIER_ATTACHMENT", x => x.ATTACHMENT_ID);
                    table.ForeignKey(
                        name: "FK_SUPPLIER_ATTACHMENT_SUPPLIER_SUPPLIER_ID",
                        column: x => x.SUPPLIER_ID,
                        principalTable: "SUPPLIER",
                        principalColumn: "SUPPLIER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMER_ATTACHMENT_CUSTOMER_ID",
                table: "CUSTOMER_ATTACHMENT",
                column: "CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SUPPLIER_CREATED_BY",
                table: "SUPPLIER",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_SUPPLIER_ATTACHMENT_SUPPLIER_ID",
                table: "SUPPLIER_ATTACHMENT",
                column: "SUPPLIER_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CUSTOMER_ATTACHMENT");

            migrationBuilder.DropTable(
                name: "SUPPLIER_ATTACHMENT");

            migrationBuilder.DropTable(
                name: "SUPPLIER");

            migrationBuilder.DropColumn(
                name: "STAFF_NAME",
                table: "STAFF");
        }
    }
}
