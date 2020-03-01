using Microsoft.EntityFrameworkCore.Migrations;

namespace Sharmila_Textile_WebApp.Migrations
{
    public partial class balancesheet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BALANCE_SHEET",
                columns: table => new
                {
                    BALANCE_SHEET_ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IN_HAND_CASH = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    IN_HAND_CHEQUE = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    BANK_BALANCE = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    IN_HOLD = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BALANCE_SHEET", x => x.BALANCE_SHEET_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BALANCE_SHEET");
        }
    }
}
