using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBase.Migrations
{
    /// <inheritdoc />
    public partial class AddProductsStorageIndexing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "ProductsStorages",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StorageId1",
                table: "ProductsStorages",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductsStorages_ProductId1",
                table: "ProductsStorages",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsStorages_StorageId1",
                table: "ProductsStorages",
                column: "StorageId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsStorages_Products_ProductId1",
                table: "ProductsStorages",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsStorages_Storage_StorageId1",
                table: "ProductsStorages",
                column: "StorageId1",
                principalTable: "Storage",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsStorages_Products_ProductId1",
                table: "ProductsStorages");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsStorages_Storage_StorageId1",
                table: "ProductsStorages");

            migrationBuilder.DropIndex(
                name: "IX_ProductsStorages_ProductId1",
                table: "ProductsStorages");

            migrationBuilder.DropIndex(
                name: "IX_ProductsStorages_StorageId1",
                table: "ProductsStorages");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "ProductsStorages");

            migrationBuilder.DropColumn(
                name: "StorageId1",
                table: "ProductsStorages");
        }
    }
}
