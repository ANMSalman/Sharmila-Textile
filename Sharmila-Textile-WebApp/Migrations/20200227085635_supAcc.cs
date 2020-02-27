using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sharmila_Textile_WebApp.Migrations
{
    public partial class supAcc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SUPPLIER_ACCOUNT",
                columns: table => new
                {
                    SUPPLIER_ACCOUNTS_ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRIPTION = table.Column<string>(type: "varchar(100)", nullable: true),
                    AMOUNT = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    ACCOUNT_TYPE = table.Column<string>(nullable: true),
                    SUPPLIER_ID = table.Column<long>(nullable: false),
                    CREATED_BY = table.Column<long>(nullable: false),
                    REMARK = table.Column<string>(type: "varchar(100)", nullable: true),
                    STATUS = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUPPLIER_ACCOUNT", x => x.SUPPLIER_ACCOUNTS_ID);
                    table.ForeignKey(
                        name: "FK_SUPPLIER_ACCOUNT_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "USER",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SUPPLIER_ACCOUNT_SUPPLIER_SUPPLIER_ID",
                        column: x => x.SUPPLIER_ID,
                        principalTable: "SUPPLIER",
                        principalColumn: "SUPPLIER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SUPPLIER_ACCOUNT_OWN_CHEQUE",
                columns: table => new
                {
                    SUPPLIER_ACCOUNTS_ID = table.Column<long>(nullable: false),
                    OWN_CHEQUE_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUPPLIER_ACCOUNT_OWN_CHEQUE", x => new { x.OWN_CHEQUE_ID, x.SUPPLIER_ACCOUNTS_ID });
                    table.ForeignKey(
                        name: "FK_SUPPLIER_ACCOUNT_OWN_CHEQUE_OWN_CHEQUE_OWN_CHEQUE_ID",
                        column: x => x.OWN_CHEQUE_ID,
                        principalTable: "OWN_CHEQUE",
                        principalColumn: "OWN_CHEQUE_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SUPPLIER_ACCOUNT_OWN_CHEQUE_SUPPLIER_ACCOUNT_SUPPLIER_ACCOUNTS_ID",
                        column: x => x.SUPPLIER_ACCOUNTS_ID,
                        principalTable: "SUPPLIER_ACCOUNT",
                        principalColumn: "SUPPLIER_ACCOUNTS_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SUPPLIER_ACCOUNT_THIRD_PARTY_CHEQUE",
                columns: table => new
                {
                    SUPPLIER_ACCOUNTS_ID = table.Column<long>(nullable: false),
                    THIRD_PARTY_CHEQUE_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUPPLIER_ACCOUNT_THIRD_PARTY_CHEQUE", x => new { x.THIRD_PARTY_CHEQUE_ID, x.SUPPLIER_ACCOUNTS_ID });
                    table.ForeignKey(
                        name: "FK_SUPPLIER_ACCOUNT_THIRD_PARTY_CHEQUE_SUPPLIER_ACCOUNT_SUPPLIER_ACCOUNTS_ID",
                        column: x => x.SUPPLIER_ACCOUNTS_ID,
                        principalTable: "SUPPLIER_ACCOUNT",
                        principalColumn: "SUPPLIER_ACCOUNTS_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SUPPLIER_ACCOUNT_THIRD_PARTY_CHEQUE_THIRD_PARTY_CHEQUE_THIRD_PARTY_CHEQUE_ID",
                        column: x => x.THIRD_PARTY_CHEQUE_ID,
                        principalTable: "THIRD_PARTY_CHEQUE",
                        principalColumn: "THIRD_PARTY_CHEQUE_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SUPPLIER_ACCOUNT_CREATED_BY",
                table: "SUPPLIER_ACCOUNT",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_SUPPLIER_ACCOUNT_SUPPLIER_ID",
                table: "SUPPLIER_ACCOUNT",
                column: "SUPPLIER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SUPPLIER_ACCOUNT_OWN_CHEQUE_SUPPLIER_ACCOUNTS_ID",
                table: "SUPPLIER_ACCOUNT_OWN_CHEQUE",
                column: "SUPPLIER_ACCOUNTS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SUPPLIER_ACCOUNT_THIRD_PARTY_CHEQUE_SUPPLIER_ACCOUNTS_ID",
                table: "SUPPLIER_ACCOUNT_THIRD_PARTY_CHEQUE",
                column: "SUPPLIER_ACCOUNTS_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SUPPLIER_ACCOUNT_OWN_CHEQUE");

            migrationBuilder.DropTable(
                name: "SUPPLIER_ACCOUNT_THIRD_PARTY_CHEQUE");

            migrationBuilder.DropTable(
                name: "SUPPLIER_ACCOUNT");
        }
    }
}
