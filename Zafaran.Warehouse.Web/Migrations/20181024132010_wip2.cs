using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Zafaran.Warehouse.Web.Migrations
{
    public partial class wip2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commodities_Units_UnitId",
                table: "Commodities");

            migrationBuilder.InsertData(
                table: "Commodities",
                columns: new[] { "Id", "AvailableAmount", "Code", "CreatedOn", "Title", "UnitId" },
                values: new object[,]
                {
                    { 1, 100, "123312312", new DateTime(2018, 10, 24, 16, 50, 9, 522, DateTimeKind.Local), "گوشت قرمز گوسفندی", 1 },
                    { 2, 400, "123312312", new DateTime(2018, 10, 24, 16, 50, 9, 523, DateTimeKind.Local), "برنج", 4 },
                    { 3, 320, "123312312", new DateTime(2018, 10, 24, 16, 50, 9, 523, DateTimeKind.Local), "رب گوجه", 1 }
                });

            migrationBuilder.UpdateData(
                table: "Resturants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2018, 10, 24, 16, 50, 9, 518, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Resturants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2018, 10, 24, 16, 50, 9, 521, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2018, 10, 24, 16, 50, 9, 521, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2018, 10, 24, 16, 50, 9, 521, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2018, 10, 24, 16, 50, 9, 521, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2018, 10, 24, 16, 50, 9, 521, DateTimeKind.Local));

            migrationBuilder.AddForeignKey(
                name: "FK_Commodities_Units_UnitId",
                table: "Commodities",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commodities_Units_UnitId",
                table: "Commodities");

            migrationBuilder.DeleteData(
                table: "Commodities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Commodities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Commodities",
                keyColumn: "Id",
                keyValue: 3);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Commodities_Units_UnitId",
                table: "Commodities",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
