using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sharmila_Textile_WebApp.Migrations
{
    public partial class cusAccounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CUSTOMER_ACCOUNT",
                columns: table => new
                {
                    CUSTOMER_ACCOUNTS_ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRIPTION = table.Column<string>(type: "varchar(100)", nullable: true),
                    AMOUNT = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    ACCOUNT_TYPE = table.Column<string>(nullable: true),
                    CUSTOMER_ID = table.Column<long>(nullable: false),
                    CREATED_BY = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMER_ACCOUNT", x => x.CUSTOMER_ACCOUNTS_ID);
                    table.ForeignKey(
                        name: "FK_CUSTOMER_ACCOUNT_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "USER",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CUSTOMER_ACCOUNT_CUSTOMER_CUSTOMER_ID",
                        column: x => x.CUSTOMER_ID,
                        principalTable: "CUSTOMER",
                        principalColumn: "CUSTOMER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMER_ACCOUNT_OWN_CHEQUE",
                columns: table => new
                {
                    CUSTOMER_ACCOUNTS_ID = table.Column<long>(nullable: false),
                    OWN_CHEQUE_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMER_ACCOUNT_OWN_CHEQUE", x => new { x.OWN_CHEQUE_ID, x.CUSTOMER_ACCOUNTS_ID });
                    table.ForeignKey(
                        name: "FK_CUSTOMER_ACCOUNT_OWN_CHEQUE_CUSTOMER_ACCOUNT_CUSTOMER_ACCOUNTS_ID",
                        column: x => x.CUSTOMER_ACCOUNTS_ID,
                        principalTable: "CUSTOMER_ACCOUNT",
                        principalColumn: "CUSTOMER_ACCOUNTS_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CUSTOMER_ACCOUNT_OWN_CHEQUE_OWN_CHEQUE_OWN_CHEQUE_ID",
                        column: x => x.OWN_CHEQUE_ID,
                        principalTable: "OWN_CHEQUE",
                        principalColumn: "OWN_CHEQUE_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMER_ACCOUNT_THIRD_PARTY_CHEQUE",
                columns: table => new
                {
                    CUSTOMER_ACCOUNTS_ID = table.Column<long>(nullable: false),
                    THIRD_PARTY_CHEQUE_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMER_ACCOUNT_THIRD_PARTY_CHEQUE", x => new { x.THIRD_PARTY_CHEQUE_ID, x.CUSTOMER_ACCOUNTS_ID });
                    table.ForeignKey(
                        name: "FK_CUSTOMER_ACCOUNT_THIRD_PARTY_CHEQUE_CUSTOMER_ACCOUNT_CUSTOMER_ACCOUNTS_ID",
                        column: x => x.CUSTOMER_ACCOUNTS_ID,
                        principalTable: "CUSTOMER_ACCOUNT",
                        principalColumn: "CUSTOMER_ACCOUNTS_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CUSTOMER_ACCOUNT_THIRD_PARTY_CHEQUE_THIRD_PARTY_CHEQUE_THIRD_PARTY_CHEQUE_ID",
                        column: x => x.THIRD_PARTY_CHEQUE_ID,
                        principalTable: "THIRD_PARTY_CHEQUE",
                        principalColumn: "THIRD_PARTY_CHEQUE_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMER_ACCOUNT_CREATED_BY",
                table: "CUSTOMER_ACCOUNT",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMER_ACCOUNT_CUSTOMER_ID",
                table: "CUSTOMER_ACCOUNT",
                column: "CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMER_ACCOUNT_OWN_CHEQUE_CUSTOMER_ACCOUNTS_ID",
                table: "CUSTOMER_ACCOUNT_OWN_CHEQUE",
                column: "CUSTOMER_ACCOUNTS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMER_ACCOUNT_THIRD_PARTY_CHEQUE_CUSTOMER_ACCOUNTS_ID",
                table: "CUSTOMER_ACCOUNT_THIRD_PARTY_CHEQUE",
                column: "CUSTOMER_ACCOUNTS_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CUSTOMER_ACCOUNT_OWN_CHEQUE");

            migrationBuilder.DropTable(
                name: "CUSTOMER_ACCOUNT_THIRD_PARTY_CHEQUE");

            migrationBuilder.DropTable(
                name: "CUSTOMER_ACCOUNT");
        }
    }
}
