using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sharmila_Textile_WebApp.Migrations
{
    public partial class ownchqadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CHEQUE_STATUS",
                columns: table => new
                {
                    CHEQUE_STATUS_ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    STATUS_NAME = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHEQUE_STATUS", x => x.CHEQUE_STATUS_ID);
                });

            migrationBuilder.CreateTable(
                name: "OWN_CHEQUE",
                columns: table => new
                {
                    OWN_CHEQUE_ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CHEQUE_CODE = table.Column<string>(type: "varchar(50)", nullable: true),
                    BANK = table.Column<string>(type: "varchar(70)", nullable: true),
                    BRANCH = table.Column<string>(type: "varchar(70)", nullable: true),
                    AMOUNT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DUE_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    REMARK = table.Column<string>(type: "varchar(100)", nullable: true),
                    STATUS = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OWN_CHEQUE", x => x.OWN_CHEQUE_ID);
                    table.ForeignKey(
                        name: "FK_OWN_CHEQUE_CHEQUE_STATUS_STATUS",
                        column: x => x.STATUS,
                        principalTable: "CHEQUE_STATUS",
                        principalColumn: "CHEQUE_STATUS_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OWN_CHEQUE_STATUS",
                table: "OWN_CHEQUE",
                column: "STATUS");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OWN_CHEQUE");

            migrationBuilder.DropTable(
                name: "CHEQUE_STATUS");
        }
    }
}
