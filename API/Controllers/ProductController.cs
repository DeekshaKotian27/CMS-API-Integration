using API.Data;
using API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
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

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var product = await _productDBContext.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            _productDBContext.Products.Remove(product);
            var value = await _productDBContext.SaveChangesAsync();
            if (value == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateProduct(int id, ProductDTO productDTO)
        {
            if (id == 0 || productDTO == null)
            {
                return BadRequest();
            }
            var product = await _productDBContext.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            product.Name = productDTO.Name;
            product.Description = productDTO.Description;
            product.Amount = productDTO.Amount;
            product.Quantity = productDTO.Quantity;
            _productDBContext.Products.Update(product);
            var value = await _productDBContext.SaveChangesAsync();
            if (value == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
