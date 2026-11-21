using E2E.Library.Enums;
using E2E.Library.Models;
using Microsoft.EntityFrameworkCore;

namespace E2E.ProductService.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductModel>().HasData(
                new ProductModel
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Name = "Men's T-Shirt",
                    Description = "A comfortable men's t-shirt.",
                    Price = 19.99m,
                    ProductType = ProductType.MenClothing,
                    MenSize = MenClothingSizeEnum.M
                },
                new ProductModel
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Name = "Women's Dress",
                    Description = "A stylish women's dress.",
                    Price = 49.99m,
                    ProductType = ProductType.WomenClothing,
                    WomenSize = WomenClothingSizeEnum.S
                }
            );
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ProductModel> Products { get; set; }
    }
}
