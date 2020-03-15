using Microsoft.EntityFrameworkCore.Migrations;

namespace Sharmila_Textile_WebApp.Migrations
{
    public partial class accountsummary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ACCOUNTABLE_CUSTOMER_ACCOUNT",
                table: "SUMMARY",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ACCOUNTABLE_SUPPLIER_ACCOUNT",
                table: "SUMMARY",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TOTAL_CUSTOMER_ACCOUNT",
                table: "SUMMARY",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TOTAL_SUPPLIER_ACCOUNT",
                table: "SUMMARY",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ACCOUNTABLE_CUSTOMER_ACCOUNT",
                table: "SUMMARY");

            migrationBuilder.DropColumn(
                name: "ACCOUNTABLE_SUPPLIER_ACCOUNT",
                table: "SUMMARY");

            migrationBuilder.DropColumn(
                name: "TOTAL_CUSTOMER_ACCOUNT",
                table: "SUMMARY");

            migrationBuilder.DropColumn(
                name: "TOTAL_SUPPLIER_ACCOUNT",
                table: "SUMMARY");
        }
    }
}
