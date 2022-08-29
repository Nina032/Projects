using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExempelProject.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2022, 8, 29, 11, 38, 39, 71, DateTimeKind.Local).AddTicks(290));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2022, 8, 29, 11, 5, 9, 797, DateTimeKind.Local).AddTicks(6112));
        }
    }
}
