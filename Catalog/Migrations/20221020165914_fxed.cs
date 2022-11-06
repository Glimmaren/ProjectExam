using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalog.Migrations
{
    public partial class fxed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceLists_Products_ProductId",
                table: "PriceLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PriceLists",
                table: "PriceLists");

            migrationBuilder.RenameTable(
                name: "PriceLists",
                newName: "PricedProducts");

            migrationBuilder.RenameColumn(
                name: "PriceListId",
                table: "PricedProducts",
                newName: "PricedProductId");

            migrationBuilder.RenameIndex(
                name: "IX_PriceLists_ProductId",
                table: "PricedProducts",
                newName: "IX_PricedProducts_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PricedProducts",
                table: "PricedProducts",
                column: "PricedProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_PricedProducts_Products_ProductId",
                table: "PricedProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PricedProducts_Products_ProductId",
                table: "PricedProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PricedProducts",
                table: "PricedProducts");

            migrationBuilder.RenameTable(
                name: "PricedProducts",
                newName: "PriceLists");

            migrationBuilder.RenameColumn(
                name: "PricedProductId",
                table: "PriceLists",
                newName: "PriceListId");

            migrationBuilder.RenameIndex(
                name: "IX_PricedProducts_ProductId",
                table: "PriceLists",
                newName: "IX_PriceLists_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PriceLists",
                table: "PriceLists",
                column: "PriceListId");

            migrationBuilder.AddForeignKey(
                name: "FK_PriceLists_Products_ProductId",
                table: "PriceLists",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
