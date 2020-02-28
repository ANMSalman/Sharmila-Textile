using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sharmila_Textile_WebApp.Migrations
{
    public partial class expenses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EXPENSE",
                columns: table => new
                {
                    EXPENSE_ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRIPTION = table.Column<string>(type: "varchar(100)", nullable: true),
                    CASH = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CHEQUE = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TOTAL_AMOUNT = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    PAYMENT_TYPE = table.Column<long>(nullable: false),
                    CREATED_BY = table.Column<long>(nullable: false),
                    REMARK = table.Column<string>(type: "varchar(100)", nullable: true),
                    STATUS = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXPENSE", x => x.EXPENSE_ID);
                    table.ForeignKey(
                        name: "FK_EXPENSE_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "USER",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EXPENSE_OWN_CHEQUE",
                columns: table => new
                {
                    EXPENSE_ID = table.Column<long>(nullable: false),
                    OWN_CHEQUE_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXPENSE_OWN_CHEQUE", x => new { x.OWN_CHEQUE_ID, x.EXPENSE_ID });
                    table.ForeignKey(
                        name: "FK_EXPENSE_OWN_CHEQUE_EXPENSE_EXPENSE_ID",
                        column: x => x.EXPENSE_ID,
                        principalTable: "EXPENSE",
                        principalColumn: "EXPENSE_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EXPENSE_OWN_CHEQUE_OWN_CHEQUE_OWN_CHEQUE_ID",
                        column: x => x.OWN_CHEQUE_ID,
                        principalTable: "OWN_CHEQUE",
                        principalColumn: "OWN_CHEQUE_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EXPENSE_THIRD_PARTY_CHEQUE",
                columns: table => new
                {
                    EXPENSE_ID = table.Column<long>(nullable: false),
                    THIRD_PARTY_CHEQUE_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXPENSE_THIRD_PARTY_CHEQUE", x => new { x.THIRD_PARTY_CHEQUE_ID, x.EXPENSE_ID });
                    table.ForeignKey(
                        name: "FK_EXPENSE_THIRD_PARTY_CHEQUE_EXPENSE_EXPENSE_ID",
                        column: x => x.EXPENSE_ID,
                        principalTable: "EXPENSE",
                        principalColumn: "EXPENSE_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EXPENSE_THIRD_PARTY_CHEQUE_THIRD_PARTY_CHEQUE_THIRD_PARTY_CHEQUE_ID",
                        column: x => x.THIRD_PARTY_CHEQUE_ID,
                        principalTable: "THIRD_PARTY_CHEQUE",
                        principalColumn: "THIRD_PARTY_CHEQUE_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EXPENSE_CREATED_BY",
                table: "EXPENSE",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_EXPENSE_OWN_CHEQUE_EXPENSE_ID",
                table: "EXPENSE_OWN_CHEQUE",
                column: "EXPENSE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EXPENSE_THIRD_PARTY_CHEQUE_EXPENSE_ID",
                table: "EXPENSE_THIRD_PARTY_CHEQUE",
                column: "EXPENSE_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EXPENSE_OWN_CHEQUE");

            migrationBuilder.DropTable(
                name: "EXPENSE_THIRD_PARTY_CHEQUE");

            migrationBuilder.DropTable(
                name: "EXPENSE");
        }
    }
}
