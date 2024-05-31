using Microsoft.EntityFrameworkCore;
using ProductMicroService.Models;

namespace ProductMicroService.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

        public DbSet<Product> products { get; set; }

    }
}
