using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sharmila_Textile_WebApp.Migrations
{
    public partial class forgotDateInPayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED_DATE",
                table: "SUPPLIER_PAYMENT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CREATED_DATE",
                table: "SUPPLIER_PAYMENT");
        }
    }
}
