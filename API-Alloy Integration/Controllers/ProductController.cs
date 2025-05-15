using API_Alloy_Integration.Data;
using API_Alloy_Integration.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Alloy_Integration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductDBContext _productDBContext;
        public ProductController(ProductDBContext productDBContext)
        {
            _productDBContext = productDBContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductData()
        {
            var data = await _productDBContext.Products.ToListAsync();
            return Ok(data);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetProductDataByID(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var data = await _productDBContext.Products.FindAsync(id);
            if(data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDTO productDTO)
        {
            if (productDTO == null)
            {
                return BadRequest();
            }
            var product = new Product()
            {
                Name = productDTO.Name,
                Description= productDTO.Description,
                Amount= productDTO.Amount,
                Quantity = productDTO.Quantity
            }; 
            await _productDBContext.Products.AddAsync(product);
            var value = await _productDBContext.SaveChangesAsync();
            if(value == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
