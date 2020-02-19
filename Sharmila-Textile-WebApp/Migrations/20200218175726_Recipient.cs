using Microsoft.EntityFrameworkCore.Migrations;

namespace Sharmila_Textile_WebApp.Migrations
{
    public partial class Recipient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "OWN_CHEQUE_ID",
                table: "OWN_CHEQUE_ACTION_LOG",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_OWN_CHEQUE_ACTION_LOG_OWN_CHEQUE_ID",
                table: "OWN_CHEQUE_ACTION_LOG",
                column: "OWN_CHEQUE_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_OWN_CHEQUE_ACTION_LOG_OWN_CHEQUE_OWN_CHEQUE_ID",
                table: "OWN_CHEQUE_ACTION_LOG",
                column: "OWN_CHEQUE_ID",
                principalTable: "OWN_CHEQUE",
                principalColumn: "OWN_CHEQUE_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OWN_CHEQUE_ACTION_LOG_OWN_CHEQUE_OWN_CHEQUE_ID",
                table: "OWN_CHEQUE_ACTION_LOG");

            migrationBuilder.DropIndex(
                name: "IX_OWN_CHEQUE_ACTION_LOG_OWN_CHEQUE_ID",
                table: "OWN_CHEQUE_ACTION_LOG");

            migrationBuilder.DropColumn(
                name: "OWN_CHEQUE_ID",
                table: "OWN_CHEQUE_ACTION_LOG");
        }
    }
}
