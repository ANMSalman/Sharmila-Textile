using Microsoft.EntityFrameworkCore.Migrations;

namespace Sharmila_Textile_WebApp.Migrations
{
    public partial class bankDepositv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BALANCE_DEPOSIT_USER_CREATED_BY",
                table: "BALANCE_DEPOSIT");

            migrationBuilder.DropForeignKey(
                name: "FK_BANK_DEPOSIT_THIRD_PARTY_CHEQUE_BALANCE_DEPOSIT_BANK_DEPOSIT_ID",
                table: "BANK_DEPOSIT_THIRD_PARTY_CHEQUE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BALANCE_DEPOSIT",
                table: "BALANCE_DEPOSIT");

            migrationBuilder.DropColumn(
                name: "BALANCE_DEPOSIT_ID",
                table: "BALANCE_DEPOSIT");

            migrationBuilder.RenameTable(
                name: "BALANCE_DEPOSIT",
                newName: "BANK_DEPOSIT");

            migrationBuilder.RenameIndex(
                name: "IX_BALANCE_DEPOSIT_CREATED_BY",
                table: "BANK_DEPOSIT",
                newName: "IX_BANK_DEPOSIT_CREATED_BY");

            migrationBuilder.AddColumn<long>(
                name: "BANK_DEPOSIT_ID",
                table: "BANK_DEPOSIT",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BANK_DEPOSIT",
                table: "BANK_DEPOSIT",
                column: "BANK_DEPOSIT_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_BANK_DEPOSIT_USER_CREATED_BY",
                table: "BANK_DEPOSIT",
                column: "CREATED_BY",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BANK_DEPOSIT_THIRD_PARTY_CHEQUE_BANK_DEPOSIT_BANK_DEPOSIT_ID",
                table: "BANK_DEPOSIT_THIRD_PARTY_CHEQUE",
                column: "BANK_DEPOSIT_ID",
                principalTable: "BANK_DEPOSIT",
                principalColumn: "BANK_DEPOSIT_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BANK_DEPOSIT_USER_CREATED_BY",
                table: "BANK_DEPOSIT");

            migrationBuilder.DropForeignKey(
                name: "FK_BANK_DEPOSIT_THIRD_PARTY_CHEQUE_BANK_DEPOSIT_BANK_DEPOSIT_ID",
                table: "BANK_DEPOSIT_THIRD_PARTY_CHEQUE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BANK_DEPOSIT",
                table: "BANK_DEPOSIT");

            migrationBuilder.DropColumn(
                name: "BANK_DEPOSIT_ID",
                table: "BANK_DEPOSIT");

            migrationBuilder.RenameTable(
                name: "BANK_DEPOSIT",
                newName: "BALANCE_DEPOSIT");

            migrationBuilder.RenameIndex(
                name: "IX_BANK_DEPOSIT_CREATED_BY",
                table: "BALANCE_DEPOSIT",
                newName: "IX_BALANCE_DEPOSIT_CREATED_BY");

            migrationBuilder.AddColumn<long>(
                name: "BALANCE_DEPOSIT_ID",
                table: "BALANCE_DEPOSIT",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BALANCE_DEPOSIT",
                table: "BALANCE_DEPOSIT",
                column: "BALANCE_DEPOSIT_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_BALANCE_DEPOSIT_USER_CREATED_BY",
                table: "BALANCE_DEPOSIT",
                column: "CREATED_BY",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BANK_DEPOSIT_THIRD_PARTY_CHEQUE_BALANCE_DEPOSIT_BANK_DEPOSIT_ID",
                table: "BANK_DEPOSIT_THIRD_PARTY_CHEQUE",
                column: "BANK_DEPOSIT_ID",
                principalTable: "BALANCE_DEPOSIT",
                principalColumn: "BALANCE_DEPOSIT_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
