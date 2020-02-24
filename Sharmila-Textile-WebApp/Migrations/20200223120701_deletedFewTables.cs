using Microsoft.EntityFrameworkCore.Migrations;

namespace Sharmila_Textile_WebApp.Migrations
{
    public partial class deletedFewTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SUPPLIER_PAYMENT_OWN_CHEQUE");

            migrationBuilder.DropTable(
                name: "SUPPLIER_PAYMENT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SUPPLIER_PAYMENT",
                columns: table => new
                {
                    SUPPLIER_PAYMENT_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CASH = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CHEQUE = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CREATED_BY = table.Column<long>(type: "bigint", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "varchar(100)", nullable: true),
                    PAYMENT_TYPE = table.Column<long>(type: "bigint", nullable: false),
                    PURCHASE = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    REMARK = table.Column<string>(type: "varchar(100)", nullable: true),
                    RETURNS = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    STATUS = table.Column<int>(type: "int", nullable: false),
                    SUPPLIER_ID = table.Column<long>(type: "bigint", nullable: false),
                    TOTAL_AMOUNT = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUPPLIER_PAYMENT", x => x.SUPPLIER_PAYMENT_ID);
                    table.ForeignKey(
                        name: "FK_SUPPLIER_PAYMENT_CHEQUE_STATUS_PAYMENT_TYPE",
                        column: x => x.PAYMENT_TYPE,
                        principalTable: "CHEQUE_STATUS",
                        principalColumn: "CHEQUE_STATUS_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SUPPLIER_PAYMENT_SUPPLIER_SUPPLIER_ID",
                        column: x => x.SUPPLIER_ID,
                        principalTable: "SUPPLIER",
                        principalColumn: "SUPPLIER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SUPPLIER_PAYMENT_OWN_CHEQUE",
                columns: table => new
                {
                    OWN_CHEQUE_ID = table.Column<long>(type: "bigint", nullable: false),
                    SUPPLIER_PAYMENT_ID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUPPLIER_PAYMENT_OWN_CHEQUE", x => new { x.OWN_CHEQUE_ID, x.SUPPLIER_PAYMENT_ID });
                    table.ForeignKey(
                        name: "FK_SUPPLIER_PAYMENT_OWN_CHEQUE_OWN_CHEQUE_OWN_CHEQUE_ID",
                        column: x => x.OWN_CHEQUE_ID,
                        principalTable: "OWN_CHEQUE",
                        principalColumn: "OWN_CHEQUE_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SUPPLIER_PAYMENT_OWN_CHEQUE_SUPPLIER_PAYMENT_SUPPLIER_PAYMENT_ID",
                        column: x => x.SUPPLIER_PAYMENT_ID,
                        principalTable: "SUPPLIER_PAYMENT",
                        principalColumn: "SUPPLIER_PAYMENT_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SUPPLIER_PAYMENT_PAYMENT_TYPE",
                table: "SUPPLIER_PAYMENT",
                column: "PAYMENT_TYPE");

            migrationBuilder.CreateIndex(
                name: "IX_SUPPLIER_PAYMENT_SUPPLIER_ID",
                table: "SUPPLIER_PAYMENT",
                column: "SUPPLIER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SUPPLIER_PAYMENT_OWN_CHEQUE_SUPPLIER_PAYMENT_ID",
                table: "SUPPLIER_PAYMENT_OWN_CHEQUE",
                column: "SUPPLIER_PAYMENT_ID");
        }
    }
}
