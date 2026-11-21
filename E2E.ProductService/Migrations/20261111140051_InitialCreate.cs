using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E2E.ProductService.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    ProductType = table.Column<int>(type: "integer", nullable: false),
                    MenSize = table.Column<int>(type: "integer", nullable: true),
                    WomenSize = table.Column<int>(type: "integer", nullable: true),
                    MenTrouserSize = table.Column<int>(type: "integer", nullable: true),
                    WomanTrouserSize = table.Column<int>(type: "integer", nullable: true),
                    MenShoeSize = table.Column<int>(type: "integer", nullable: true),
                    WomenShoeSize = table.Column<int>(type: "integer", nullable: true),
                    MenWatchSize = table.Column<int>(type: "integer", nullable: true),
                    WomenWatchSize = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "MenShoeSize", "MenSize", "MenTrouserSize", "MenWatchSize", "Name", "Price", "ProductType", "WomanTrouserSize", "WomenShoeSize", "WomenSize", "WomenWatchSize" },
                values: new object[,]
                {
                    { new Guid("c65f29cd-ae13-4920-9a07-b387f5a71abc"), "A stylish women's dress.", null, null, null, null, "Women's Dress", 49.99m, 4, null, null, 1, null },
                    { new Guid("cb2a1c22-9193-4c38-81a9-3953baecca7f"), "A comfortable men's t-shirt.", null, 2, null, null, "Men's T-Shirt", 19.99m, 0, null, null, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
