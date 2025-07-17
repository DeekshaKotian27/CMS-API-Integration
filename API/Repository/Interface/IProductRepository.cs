using API.DTO;
using API.Model;

namespace API.Repository.Interface
{
    public interface IProductRepository
    {
        Task<APIResponse> GetProducts();
        Task<APIResponse> GetProductByID(int id);
        Task<APIResponse> CreateProduct(ProductDTO product);
        Task<APIResponse> DeleteProduct(int id);
        Task<APIResponse> UpdateProduct(int id,ProductDTO productDTO);
    }
}
