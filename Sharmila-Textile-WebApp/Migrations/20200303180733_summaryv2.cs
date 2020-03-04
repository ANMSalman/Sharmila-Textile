using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sharmila_Textile_WebApp.Migrations
{
    public partial class summaryv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SUMMARY",
                columns: table => new
                {
                    SUMMARY_ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BTT_BILLS = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    NORMAL_BILLS = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TOTAL_AMOUNT = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TOTAL_COLLECTION = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ACCOUNTABLE_COLLECTION = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TOTAL_PAYMENT = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ACCOUNTABLE_PAYMENT = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TOTAL_EXPENSE = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ACCOUNTABLE_EXPENSE = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TOTAL_BANK_DEPOSIT = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ACCOUNTABLE_BANK_DEPOSIT = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    SUMMARY_TOTAL = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CASH_BALANCE = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CHEQUE_BALANCE = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    DATE = table.Column<DateTime>(nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    STATUS = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUMMARY", x => x.SUMMARY_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SUMMARY");
        }
    }
}
