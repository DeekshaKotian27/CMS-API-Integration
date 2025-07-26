using CMS.APIServices;
using CMS.APIServices.Model;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Blocks.Controllers
{
    //[Route("[controller]/[action]")]
    public class AddProductController : Controller
    {
        private readonly IAPIBaseService _apiService;
        public AddProductController(IAPIBaseService aPIBaseService)
        {
            _apiService = aPIBaseService;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct([FromBody]ProductView product)
        {
            var apiRequest = new APIRequest()
            {
                APIType = APIMethod.APIType.POST,
                URL = product.ApiURL,
                Data =new Product()
                {
                    Name=product.Name,
                    Description=product.Description,
                    Amount=product.Amount,
                    Quantity=product.Quantity
                }
            };
            var response = await _apiService.SendAsync<APIResponse>(apiRequest);
            if (response.Success) { return Ok(response); }
            return StatusCode(response.StatusCode,response);
        }
    }
}
