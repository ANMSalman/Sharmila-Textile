using Microsoft.EntityFrameworkCore.Migrations;

namespace Sharmila_Textile_WebApp.Migrations
{
    public partial class Thirdpartytablev2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "FROM",
                table: "THIRD_PARTY_CHEQUE",
                type: "varchar(70)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FROM_REFERENCE_ID",
                table: "THIRD_PARTY_CHEQUE",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FROM_REFERENCE_NOTE",
                table: "THIRD_PARTY_CHEQUE",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FROM",
                table: "THIRD_PARTY_CHEQUE");

            migrationBuilder.DropColumn(
                name: "FROM_REFERENCE_ID",
                table: "THIRD_PARTY_CHEQUE");

            migrationBuilder.DropColumn(
                name: "FROM_REFERENCE_NOTE",
                table: "THIRD_PARTY_CHEQUE");

            migrationBuilder.AddColumn<string>(
                name: "FROM",
                table: "THIRD_PARTY_CHEQUE_ACTION_LOG",
                type: "varchar(70)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FROM_REFERENCE_ID",
                table: "THIRD_PARTY_CHEQUE_ACTION_LOG",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FROM_REFERENCE_NOTE",
                table: "THIRD_PARTY_CHEQUE_ACTION_LOG",
                type: "bigint",
                nullable: true);
        }
    }
}
