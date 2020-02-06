using Microsoft.EntityFrameworkCore.Migrations;

namespace Sharmila_Textile_WebApp.Migrations
{
    public partial class Initiate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "STAFF",
                columns: table => new
                {
                    STAFF_ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NIC = table.Column<string>(type: "varchar(12)", nullable: true),
                    ADDRESS = table.Column<string>(type: "varchar(max)", nullable: true),
                    CONTACT_NO = table.Column<string>(type: "varchar(10)", nullable: true),
                    CURRENT_STATUS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STAFF", x => x.STAFF_ID);
                });

            migrationBuilder.CreateTable(
                name: "STAFF_ATTACHMENT",
                columns: table => new
                {
                    ATTACHMENT_ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ATTACHMENT_NAME = table.Column<string>(type: "varchar(max)", nullable: true),
                    ATTACHMENT_PATH = table.Column<string>(type: "varchar(max)", nullable: true),
                    STAFF_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STAFF_ATTACHMENT", x => x.ATTACHMENT_ID);
                    table.ForeignKey(
                        name: "FK_STAFF_ATTACHMENT_STAFF_STAFF_ID",
                        column: x => x.STAFF_ID,
                        principalTable: "STAFF",
                        principalColumn: "STAFF_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_STAFF_ATTACHMENT_STAFF_ID",
                table: "STAFF_ATTACHMENT",
                column: "STAFF_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "STAFF_ATTACHMENT");

            migrationBuilder.DropTable(
                name: "STAFF");
        }
    }
}
