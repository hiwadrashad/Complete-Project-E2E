using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E2E.OrderService.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    DeliveryStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductModel",
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
                    WomenWatchSize = table.Column<int>(type: "integer", nullable: true),
                    OrderModelId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductModel_Orders_OrderModelId",
                        column: x => x.OrderModelId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "DeliveryStatus", "OrderDate", "Status", "TotalAmount", "UserId" },
                values: new object[] { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), 0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, 69.98m, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb") });

            migrationBuilder.CreateIndex(
                name: "IX_ProductModel_OrderModelId",
                table: "ProductModel",
                column: "OrderModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductModel");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
