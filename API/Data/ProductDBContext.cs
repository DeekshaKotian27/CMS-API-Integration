using CMS_API_Integration.Model;
using Microsoft.EntityFrameworkCore;

namespace CMS_API_Integration.Data
{
    public class ProductDBContext: DbContext
    {
        public ProductDBContext(DbContextOptions<ProductDBContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
    
}
