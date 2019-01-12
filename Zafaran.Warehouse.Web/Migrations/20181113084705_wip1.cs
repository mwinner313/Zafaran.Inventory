using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Zafaran.Warehouse.Web.Migrations
{
    public partial class wip1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckoutedLineItem_Commodities_CommodityId",
                table: "CheckoutedLineItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckoutedLineItem_CommodityRequestFormLineItem_FormRequestLineItemId",
                table: "CheckoutedLineItem");

            migrationBuilder.DropIndex(
                name: "IX_CheckoutedLineItem_FormRequestLineItemId",
                table: "CheckoutedLineItem");

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "CommodityRequestCheckouts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CommodityId",
                table: "CheckoutedLineItem",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequiredAmount",
                table: "CheckoutedLineItem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Commodities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2018, 11, 13, 12, 17, 4, 769, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Commodities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2018, 11, 13, 12, 17, 4, 769, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Commodities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2018, 11, 13, 12, 17, 4, 769, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Resturants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2018, 11, 13, 12, 17, 4, 765, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Resturants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2018, 11, 13, 12, 17, 4, 767, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2018, 11, 13, 12, 17, 4, 768, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2018, 11, 13, 12, 17, 4, 767, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2018, 11, 13, 12, 17, 4, 768, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2018, 11, 13, 12, 17, 4, 768, DateTimeKind.Local));

            migrationBuilder.AddForeignKey(
                name: "FK_CheckoutedLineItem_Commodities_CommodityId",
                table: "CheckoutedLineItem",
                column: "CommodityId",
                principalTable: "Commodities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckoutedLineItem_Commodities_CommodityId",
                table: "CheckoutedLineItem");

            migrationBuilder.DropColumn(
                name: "State",
                table: "CommodityRequestCheckouts");

            migrationBuilder.DropColumn(
                name: "RequiredAmount",
                table: "CheckoutedLineItem");

            migrationBuilder.AlterColumn<int>(
                name: "CommodityId",
                table: "CheckoutedLineItem",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "Commodities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2018, 10, 24, 16, 50, 9, 522, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Commodities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2018, 10, 24, 16, 50, 9, 523, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Commodities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2018, 10, 24, 16, 50, 9, 523, DateTimeKind.Local));

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

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutedLineItem_FormRequestLineItemId",
                table: "CheckoutedLineItem",
                column: "FormRequestLineItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckoutedLineItem_Commodities_CommodityId",
                table: "CheckoutedLineItem",
                column: "CommodityId",
                principalTable: "Commodities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckoutedLineItem_CommodityRequestFormLineItem_FormRequestLineItemId",
                table: "CheckoutedLineItem",
                column: "FormRequestLineItemId",
                principalTable: "CommodityRequestFormLineItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
