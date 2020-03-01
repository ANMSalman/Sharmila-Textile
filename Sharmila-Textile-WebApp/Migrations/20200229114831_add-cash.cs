using Microsoft.EntityFrameworkCore.Migrations;

namespace Sharmila_Textile_WebApp.Migrations
{
    public partial class addcash : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "IN_HAND_CASH",
                table: "SUPPLIER_PAYMENT",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "IN_HAND_CASH",
                table: "EXPENSE",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "IN_HAND_CASH",
                table: "COLLECTION",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IN_HAND_CASH",
                table: "SUPPLIER_PAYMENT");

            migrationBuilder.DropColumn(
                name: "IN_HAND_CASH",
                table: "EXPENSE");

            migrationBuilder.DropColumn(
                name: "IN_HAND_CASH",
                table: "COLLECTION");
        }
    }
}
