using CustomerMicroService.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerMicroService.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> customers { get; set; }
    }
}
