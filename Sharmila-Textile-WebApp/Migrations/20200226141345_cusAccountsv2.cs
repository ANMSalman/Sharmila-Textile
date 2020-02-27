using Microsoft.EntityFrameworkCore.Migrations;

namespace Sharmila_Textile_WebApp.Migrations
{
    public partial class cusAccountsv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "REMARK",
                table: "CUSTOMER_ACCOUNT",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "STATUS",
                table: "CUSTOMER_ACCOUNT",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "REMARK",
                table: "CUSTOMER_ACCOUNT");

            migrationBuilder.DropColumn(
                name: "STATUS",
                table: "CUSTOMER_ACCOUNT");
        }
    }
}
