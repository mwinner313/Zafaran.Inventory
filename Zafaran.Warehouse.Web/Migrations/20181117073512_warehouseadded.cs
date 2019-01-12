using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Zafaran.Warehouse.Web.Migrations
{
    public partial class warehouseadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableAmount",
                table: "Commodities");

            migrationBuilder.CreateTable(
                name: "WareHouses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WareHouses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommidityWarehouseInventories",
                columns: table => new
                {
                    CommodityId = table.Column<int>(nullable: false),
                    WareHouseId = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommidityWarehouseInventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommidityWarehouseInventories_Commodities_CommodityId",
                        column: x => x.CommodityId,
                        principalTable: "Commodities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommidityWarehouseInventories_WareHouses_WareHouseId",
                        column: x => x.WareHouseId,
                        principalTable: "WareHouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Commodities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2018, 11, 17, 11, 5, 11, 530, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Commodities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2018, 11, 17, 11, 5, 11, 530, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Commodities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2018, 11, 17, 11, 5, 11, 530, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Resturants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2018, 11, 17, 11, 5, 11, 526, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Resturants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2018, 11, 17, 11, 5, 11, 528, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2018, 11, 17, 11, 5, 11, 529, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2018, 11, 17, 11, 5, 11, 529, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2018, 11, 17, 11, 5, 11, 529, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2018, 11, 17, 11, 5, 11, 529, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_CommidityWarehouseInventories_CommodityId",
                table: "CommidityWarehouseInventories",
                column: "CommodityId");

            migrationBuilder.CreateIndex(
                name: "IX_CommidityWarehouseInventories_WareHouseId",
                table: "CommidityWarehouseInventories",
                column: "WareHouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommidityWarehouseInventories");

            migrationBuilder.DropTable(
                name: "WareHouses");

            migrationBuilder.AddColumn<int>(
                name: "AvailableAmount",
                table: "Commodities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Commodities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvailableAmount", "CreatedOn" },
                values: new object[] { 100, new DateTime(2018, 11, 13, 12, 17, 4, 769, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Commodities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvailableAmount", "CreatedOn" },
                values: new object[] { 400, new DateTime(2018, 11, 13, 12, 17, 4, 769, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Commodities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvailableAmount", "CreatedOn" },
                values: new object[] { 320, new DateTime(2018, 11, 13, 12, 17, 4, 769, DateTimeKind.Local) });

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
        }
    }
}
