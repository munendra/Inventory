using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventory.Domain.Migrations
{
    public partial class updateEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_OrderDetail_OrderDetailId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_OrderDetailId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "OrderDetailId",
                table: "Items");

            migrationBuilder.AddColumn<Guid>(
                name: "ItemId",
                table: "OrderDetail",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ItemId",
                table: "OrderDetail",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Items_ItemId",
                table: "OrderDetail",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Items_ItemId",
                table: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_ItemId",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "OrderDetail");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderDetailId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_OrderDetailId",
                table: "Items",
                column: "OrderDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_OrderDetail_OrderDetailId",
                table: "Items",
                column: "OrderDetailId",
                principalTable: "OrderDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
