using E2E.Library.Enums;
using E2E.Library.Models;
using Microsoft.EntityFrameworkCore;

namespace E2E.OrderService.Data
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderModel>().HasData(
                new OrderModel
                {
                    Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    UserId = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                    TotalAmount = 69.98m,
                    OrderDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    Status = StatusEnum.OutOfStock,
                    DeliveryStatus = DeliveryStatusEnum.Pending
                }
            );
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<OrderModel> Orders { get; set; }
    }
}
