using Microsoft.EntityFrameworkCore.Migrations;

namespace Sharmila_Textile_WebApp.Migrations
{
    public partial class thirdParty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SUPPLIER_PAYMENT_THIRD_PARTY_CHEQUE",
                columns: table => new
                {
                    SUPPLIER_PAYMENT_ID = table.Column<long>(nullable: false),
                    THIRD_PARTY_CHEQUE_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUPPLIER_PAYMENT_THIRD_PARTY_CHEQUE", x => new { x.THIRD_PARTY_CHEQUE_ID, x.SUPPLIER_PAYMENT_ID });
                    table.ForeignKey(
                        name: "FK_SUPPLIER_PAYMENT_THIRD_PARTY_CHEQUE_SUPPLIER_PAYMENT_SUPPLIER_PAYMENT_ID",
                        column: x => x.SUPPLIER_PAYMENT_ID,
                        principalTable: "SUPPLIER_PAYMENT",
                        principalColumn: "SUPPLIER_PAYMENT_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SUPPLIER_PAYMENT_THIRD_PARTY_CHEQUE_THIRD_PARTY_CHEQUE_THIRD_PARTY_CHEQUE_ID",
                        column: x => x.THIRD_PARTY_CHEQUE_ID,
                        principalTable: "THIRD_PARTY_CHEQUE",
                        principalColumn: "THIRD_PARTY_CHEQUE_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SUPPLIER_PAYMENT_THIRD_PARTY_CHEQUE_SUPPLIER_PAYMENT_ID",
                table: "SUPPLIER_PAYMENT_THIRD_PARTY_CHEQUE",
                column: "SUPPLIER_PAYMENT_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SUPPLIER_PAYMENT_THIRD_PARTY_CHEQUE");
        }
    }
}
