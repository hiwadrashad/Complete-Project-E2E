using E2E.Library.Models;
using E2E.ProductService.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E2E.ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(ProductDbContext dbContext) : Controller
    {
        [HttpGet]
        public async Task<List<ProductModel>> GetProducts()
        {
            return await dbContext.Products.ToListAsync();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProductModel>> GetProduct(Guid id)
        {
            var product = await dbContext.Products.FindAsync(id);
            return product is null ? NotFound() : Ok(product);
        }
    }
}
