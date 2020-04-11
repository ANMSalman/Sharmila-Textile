using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sharmila_Textile_WebApp.Migrations
{
    public partial class collectiondate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LAST_COLLECTION_DATE",
                table: "CUSTOMER",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LAST_COLLECTION_DATE",
                table: "CUSTOMER");
        }
    }
}
