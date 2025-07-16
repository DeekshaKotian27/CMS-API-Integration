using API.Model;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ProductDBContext: DbContext
    {
        public ProductDBContext(DbContextOptions<ProductDBContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
    
}
