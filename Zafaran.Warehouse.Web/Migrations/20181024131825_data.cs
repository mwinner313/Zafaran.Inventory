using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Zafaran.Warehouse.Web.Migrations
{
    public partial class data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Resturants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2018, 10, 24, 16, 48, 25, 218, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Resturants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2018, 10, 24, 16, 48, 25, 220, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2018, 10, 24, 16, 48, 25, 221, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2018, 10, 24, 16, 48, 25, 221, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2018, 10, 24, 16, 48, 25, 221, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2018, 10, 24, 16, 48, 25, 221, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Resturants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2018, 10, 24, 16, 43, 58, 495, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Resturants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2018, 10, 24, 16, 43, 58, 497, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2018, 10, 24, 16, 43, 58, 498, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2018, 10, 24, 16, 43, 58, 498, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2018, 10, 24, 16, 43, 58, 498, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2018, 10, 24, 16, 43, 58, 498, DateTimeKind.Local));
        }
    }
}
