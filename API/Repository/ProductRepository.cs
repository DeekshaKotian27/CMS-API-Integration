using API.Data;
using API.DTO;
using API.Model;
using API.Repository.Interface;
using Azure;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDBContext _productDBContext;
        public ProductRepository(ProductDBContext productDBContext)
        {
            _productDBContext = productDBContext;
        }

        public async Task<APIResponse> CreateProduct(ProductDTO productDTO)
        {
            var apiResponse = new APIResponse();
            var productData = new Product()
            {
                Name = productDTO.Name,
                Description = productDTO.Description,
                Amount = productDTO.Amount,
                Quantity = productDTO.Quantity
            };
            await _productDBContext.Products.AddAsync(productData);
            var value = await _productDBContext.SaveChangesAsync();
            if (value == 0)
            {
                return apiResponse.FailureMessage(400, "Failed to provess the request");
            }
            return apiResponse.SuccessMessage(201);
        }

        public async Task<APIResponse> DeleteProduct(int id)
        {
            var apiResponse = new APIResponse();
            var product = await _productDBContext.Products.FindAsync(id);
            if (product == null)
            {
                return apiResponse.FailureMessage(404, "Data not found for the given id");
            }
            _productDBContext.Products.Remove(product);
            var value = await _productDBContext.SaveChangesAsync();
            if (value == 0)
            {
                return apiResponse.FailureMessage(500, "Internal server error");
            }
            return apiResponse.SuccessMessage(200);
        }

        public async Task<APIResponse> GetProductByID(int id)
        {
            var apiResponse = new APIResponse();
            var data = await _productDBContext.Products.FindAsync(id);
            if (data == null)
            {
                return apiResponse.FailureMessage(404, "Data not found");
            }
            var productDTO = new ProductDTO()
            {
                Name = data.Name,
                Description = data.Description,
                Amount = data.Amount,
                Quantity = data.Quantity,
            };
            return apiResponse.SuccessMessage(200, productDTO);
        }

        public async Task<APIResponse> GetProducts()
        {
            var data = await _productDBContext.Products.ToListAsync();
            var apiResponse = new APIResponse();
            if(data == null)
            {
                return apiResponse.FailureMessage(500, "Error Getting the data");
            }
            return apiResponse.SuccessMessage(200, data);
        }

        public async Task<APIResponse> UpdateProduct(int id, ProductDTO productDTO)
        {
            var apiResponse = new APIResponse();
            var product = await _productDBContext.Products.FindAsync(id);
            if (product == null)
            {
                return apiResponse.FailureMessage(404, "Data not found for the given id");
            }
            product.Name = productDTO.Name;
            product.Description = productDTO.Description;
            product.Amount = productDTO.Amount;
            product.Quantity = productDTO.Quantity;
            _productDBContext.Products.Update(product);
            var value = await _productDBContext.SaveChangesAsync();
            if (value == 0)
            {
                return apiResponse.FailureMessage(500, "Internal server error");
            }
            return apiResponse.SuccessMessage(200,product);
        }
    }
}
