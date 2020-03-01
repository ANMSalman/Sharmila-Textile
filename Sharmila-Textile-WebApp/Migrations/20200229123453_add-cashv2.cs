using Microsoft.EntityFrameworkCore.Migrations;

namespace Sharmila_Textile_WebApp.Migrations
{
    public partial class addcashv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IN_HAND_CASH",
                table: "COLLECTION");

            migrationBuilder.AddColumn<decimal>(
                name: "IN_HAND_CASH",
                table: "CUSTOMER_ACCOUNT",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IN_HAND_CASH",
                table: "CUSTOMER_ACCOUNT");

            migrationBuilder.AddColumn<decimal>(
                name: "IN_HAND_CASH",
                table: "COLLECTION",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
