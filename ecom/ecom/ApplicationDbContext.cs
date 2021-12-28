using Microsoft.EntityFrameworkCore;
using ecom.Models;
namespace ecom
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Product> Products { get; set; }
    }
}
