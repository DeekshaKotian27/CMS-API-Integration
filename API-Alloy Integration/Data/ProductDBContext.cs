using API_Alloy_Integration.Model;
using Microsoft.EntityFrameworkCore;

namespace API_Alloy_Integration.Data
{
    public class ProductDBContext: DbContext
    {
        public ProductDBContext(DbContextOptions<ProductDBContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
    
}
