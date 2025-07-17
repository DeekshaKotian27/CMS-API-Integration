using API.Data;
using API.DTO;
using API.Model;
using API.Repository.Interface;
using Azure;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductData()
        {
            var response= await _productRepository.GetProducts();
            return StatusCodeResult.GetStatusCode(response);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetProductDataByID(int id)
        {
            if (id == 0)
            {
                return StatusCodeResult.GetStatusCode(new APIResponse().FailureMessage(400,"ID missing"));
            }
            var data = await _productRepository.GetProductByID(id);
            return StatusCodeResult.GetStatusCode(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDTO productDTO)
        {
            if (productDTO == null)
            {
                return StatusCodeResult.GetStatusCode(new APIResponse().FailureMessage(400, "Invalid Request"));
            }
            var value = await _productRepository.CreateProduct(productDTO);
            return StatusCodeResult.GetStatusCode(value);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (id == 0)
            {
                return StatusCodeResult.GetStatusCode(new APIResponse().FailureMessage(400,"ID is required"));
            }
            var response = await _productRepository.DeleteProduct(id);
            return StatusCodeResult.GetStatusCode(response);
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateProduct(int id, ProductDTO productDTO)
        {
            if (id == 0 || productDTO == null)
            {
                return StatusCodeResult.GetStatusCode(new APIResponse().FailureMessage(400, "ID/Value is null"));
            }
            var response= await _productRepository.UpdateProduct(id,productDTO);
            return StatusCodeResult.GetStatusCode(response);
        }

    }
}
