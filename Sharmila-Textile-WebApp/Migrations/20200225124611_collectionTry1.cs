using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sharmila_Textile_WebApp.Migrations
{
    public partial class collectionTry1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "COLLECTION",
                columns: table => new
                {
                    COLLECTION_ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRIPTION = table.Column<string>(type: "varchar(100)", nullable: true),
                    CASH = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CHEQUE = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    RETURNS = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TOTAL_AMOUNT = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    COLLECTION_TYPE = table.Column<long>(nullable: false),
                    CUSTOMER_ID = table.Column<long>(nullable: false),
                    CREATED_BY = table.Column<long>(nullable: false),
                    REMARK = table.Column<string>(type: "varchar(100)", nullable: true),
                    STATUS = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COLLECTION", x => x.COLLECTION_ID);
                    table.ForeignKey(
                        name: "FK_COLLECTION_CHEQUE_STATUS_COLLECTION_TYPE",
                        column: x => x.COLLECTION_TYPE,
                        principalTable: "CHEQUE_STATUS",
                        principalColumn: "CHEQUE_STATUS_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_COLLECTION_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "USER",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COLLECTION_CUSTOMER_CUSTOMER_ID",
                        column: x => x.CUSTOMER_ID,
                        principalTable: "CUSTOMER",
                        principalColumn: "CUSTOMER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "COLLECTION_OWN_CHEQUE",
                columns: table => new
                {
                    COLLECTION_ID = table.Column<long>(nullable: false),
                    OWN_CHEQUE_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COLLECTION_OWN_CHEQUE", x => new { x.OWN_CHEQUE_ID, x.COLLECTION_ID });
                    table.ForeignKey(
                        name: "FK_COLLECTION_OWN_CHEQUE_COLLECTION_COLLECTION_ID",
                        column: x => x.COLLECTION_ID,
                        principalTable: "COLLECTION",
                        principalColumn: "COLLECTION_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COLLECTION_OWN_CHEQUE_OWN_CHEQUE_OWN_CHEQUE_ID",
                        column: x => x.OWN_CHEQUE_ID,
                        principalTable: "OWN_CHEQUE",
                        principalColumn: "OWN_CHEQUE_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "COLLECTION_THIRD_PARTY_CHEQUE",
                columns: table => new
                {
                    COLLECTION_ID = table.Column<long>(nullable: false),
                    THIRD_PARTY_CHEQUE_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COLLECTION_THIRD_PARTY_CHEQUE", x => new { x.THIRD_PARTY_CHEQUE_ID, x.COLLECTION_ID });
                    table.ForeignKey(
                        name: "FK_COLLECTION_THIRD_PARTY_CHEQUE_COLLECTION_COLLECTION_ID",
                        column: x => x.COLLECTION_ID,
                        principalTable: "COLLECTION",
                        principalColumn: "COLLECTION_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COLLECTION_THIRD_PARTY_CHEQUE_THIRD_PARTY_CHEQUE_THIRD_PARTY_CHEQUE_ID",
                        column: x => x.THIRD_PARTY_CHEQUE_ID,
                        principalTable: "THIRD_PARTY_CHEQUE",
                        principalColumn: "THIRD_PARTY_CHEQUE_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_COLLECTION_COLLECTION_TYPE",
                table: "COLLECTION",
                column: "COLLECTION_TYPE");

            migrationBuilder.CreateIndex(
                name: "IX_COLLECTION_CREATED_BY",
                table: "COLLECTION",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_COLLECTION_CUSTOMER_ID",
                table: "COLLECTION",
                column: "CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_COLLECTION_OWN_CHEQUE_COLLECTION_ID",
                table: "COLLECTION_OWN_CHEQUE",
                column: "COLLECTION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_COLLECTION_THIRD_PARTY_CHEQUE_COLLECTION_ID",
                table: "COLLECTION_THIRD_PARTY_CHEQUE",
                column: "COLLECTION_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COLLECTION_OWN_CHEQUE");

            migrationBuilder.DropTable(
                name: "COLLECTION_THIRD_PARTY_CHEQUE");

            migrationBuilder.DropTable(
                name: "COLLECTION");
        }
    }
}
