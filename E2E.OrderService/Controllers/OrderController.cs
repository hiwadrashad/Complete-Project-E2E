using E2E.Library.Models;
using E2E.OrderService.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E2E.OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(OrderDbContext DbContext) : Controller
    {
        [HttpGet]
        public async Task<List<OrderModel>> GetOrders()
        {
            return await DbContext.Orders.ToListAsync();
        }
    }
}
