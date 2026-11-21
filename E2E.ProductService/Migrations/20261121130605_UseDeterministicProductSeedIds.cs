using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E2E.ProductService.Migrations
{
    /// <inheritdoc />
    public partial class UseDeterministicProductSeedIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c65f29cd-ae13-4920-9a07-b387f5a71abc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cb2a1c22-9193-4c38-81a9-3953baecca7f"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "MenShoeSize", "MenSize", "MenTrouserSize", "MenWatchSize", "Name", "Price", "ProductType", "WomanTrouserSize", "WomenShoeSize", "WomenSize", "WomenWatchSize" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "A comfortable men's t-shirt.", null, 2, null, null, "Men's T-Shirt", 19.99m, 0, null, null, null, null },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "A stylish women's dress.", null, null, null, null, "Women's Dress", 49.99m, 4, null, null, 1, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "MenShoeSize", "MenSize", "MenTrouserSize", "MenWatchSize", "Name", "Price", "ProductType", "WomanTrouserSize", "WomenShoeSize", "WomenSize", "WomenWatchSize" },
                values: new object[,]
                {
                    { new Guid("c65f29cd-ae13-4920-9a07-b387f5a71abc"), "A stylish women's dress.", null, null, null, null, "Women's Dress", 49.99m, 4, null, null, 1, null },
                    { new Guid("cb2a1c22-9193-4c38-81a9-3953baecca7f"), "A comfortable men's t-shirt.", null, 2, null, null, "Men's T-Shirt", 19.99m, 0, null, null, null, null }
                });
        }
    }
}
