using Microsoft.EntityFrameworkCore.Migrations;

namespace Sharmila_Textile_WebApp.Migrations
{
    public partial class Thirdpartytable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CHEQUE_FROM");

            migrationBuilder.AddColumn<string>(
                name: "FROM",
                table: "THIRD_PARTY_CHEQUE_ACTION_LOG",
                type: "varchar(70)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FROM_REFERENCE_ID",
                table: "THIRD_PARTY_CHEQUE_ACTION_LOG",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FROM_REFERENCE_NOTE",
                table: "THIRD_PARTY_CHEQUE_ACTION_LOG",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FROM",
                table: "THIRD_PARTY_CHEQUE_ACTION_LOG");

            migrationBuilder.DropColumn(
                name: "FROM_REFERENCE_ID",
                table: "THIRD_PARTY_CHEQUE_ACTION_LOG");

            migrationBuilder.DropColumn(
                name: "FROM_REFERENCE_NOTE",
                table: "THIRD_PARTY_CHEQUE_ACTION_LOG");

            migrationBuilder.CreateTable(
                name: "CHEQUE_FROM",
                columns: table => new
                {
                    CHEQUE_FROM_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FROM = table.Column<string>(type: "varchar(70)", nullable: true),
                    FROM_REFERENCE_ID = table.Column<long>(type: "bigint", nullable: true),
                    FROM_REFERENCE_NOTE = table.Column<long>(type: "bigint", nullable: true),
                    REMARK = table.Column<string>(type: "varchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHEQUE_FROM", x => x.CHEQUE_FROM_ID);
                });
        }
    }
}
