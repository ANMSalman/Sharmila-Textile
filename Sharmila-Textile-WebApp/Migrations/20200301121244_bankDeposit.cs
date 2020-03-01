using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sharmila_Textile_WebApp.Migrations
{
    public partial class bankDeposit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BALANCE_DEPOSIT",
                columns: table => new
                {
                    BALANCE_DEPOSIT_ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CASH = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    IN_HAND_CASH = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    CREATED_BY = table.Column<long>(nullable: false),
                    STATUS = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BALANCE_DEPOSIT", x => x.BALANCE_DEPOSIT_ID);
                    table.ForeignKey(
                        name: "FK_BALANCE_DEPOSIT_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "USER",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BANK_DEPOSIT_THIRD_PARTY_CHEQUE",
                columns: table => new
                {
                    BANK_DEPOSIT_ID = table.Column<long>(nullable: false),
                    THIRD_PARTY_CHEQUE_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BANK_DEPOSIT_THIRD_PARTY_CHEQUE", x => new { x.THIRD_PARTY_CHEQUE_ID, x.BANK_DEPOSIT_ID });
                    table.ForeignKey(
                        name: "FK_BANK_DEPOSIT_THIRD_PARTY_CHEQUE_BALANCE_DEPOSIT_BANK_DEPOSIT_ID",
                        column: x => x.BANK_DEPOSIT_ID,
                        principalTable: "BALANCE_DEPOSIT",
                        principalColumn: "BALANCE_DEPOSIT_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BANK_DEPOSIT_THIRD_PARTY_CHEQUE_THIRD_PARTY_CHEQUE_THIRD_PARTY_CHEQUE_ID",
                        column: x => x.THIRD_PARTY_CHEQUE_ID,
                        principalTable: "THIRD_PARTY_CHEQUE",
                        principalColumn: "THIRD_PARTY_CHEQUE_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BALANCE_DEPOSIT_CREATED_BY",
                table: "BALANCE_DEPOSIT",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_BANK_DEPOSIT_THIRD_PARTY_CHEQUE_BANK_DEPOSIT_ID",
                table: "BANK_DEPOSIT_THIRD_PARTY_CHEQUE",
                column: "BANK_DEPOSIT_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BANK_DEPOSIT_THIRD_PARTY_CHEQUE");

            migrationBuilder.DropTable(
                name: "BALANCE_DEPOSIT");
        }
    }
}
