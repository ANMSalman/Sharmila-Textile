using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sharmila_Textile_WebApp.Migrations
{
    public partial class CustomerCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    USER_ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USERNAME = table.Column<string>(type: "varchar(10)", nullable: true),
                    PASSWORD = table.Column<string>(type: "varchar(50)", nullable: true),
                    CURRENT_STATUS = table.Column<int>(type: "int", nullable: false),
                    STAFF_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.USER_ID);
                    table.ForeignKey(
                        name: "FK_USER_STAFF_STAFF_ID",
                        column: x => x.STAFF_ID,
                        principalTable: "STAFF",
                        principalColumn: "STAFF_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMER",
                columns: table => new
                {
                    CUSTOMER_ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CUSTOMER_NAME = table.Column<string>(type: "varchar(50)", nullable: true),
                    NIC = table.Column<string>(type: "nchar(10)", nullable: true),
                    HOME_ADDRESS = table.Column<string>(type: "varchar(max)", nullable: true),
                    HOME_LAND_LINE = table.Column<string>(type: "nchar(10)", nullable: true),
                    OFFICE_ADDRESS = table.Column<string>(type: "varchar(max)", nullable: true),
                    OFFICE_LAND_LINE = table.Column<string>(type: "nchar(10)", nullable: true),
                    MOBILE = table.Column<string>(type: "nchar(10)", nullable: true),
                    OPENING_BALANCE = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CURRENT_BALANCE = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    CREATED_BY = table.Column<long>(nullable: false),
                    CURRENT_STATUS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMER", x => x.CUSTOMER_ID);
                    table.ForeignKey(
                        name: "FK_CUSTOMER_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "USER",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMER_CREATED_BY",
                table: "CUSTOMER",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_USER_STAFF_ID",
                table: "USER",
                column: "STAFF_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CUSTOMER");

            migrationBuilder.DropTable(
                name: "USER");
        }
    }
}
