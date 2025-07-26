using CMS.APIServices.Model;

namespace CMS.APIServices
{
    public interface IAPIBaseService
    {
        APIResponse APIResponse { get; set; }

        Task<T> SendAsync<T>(APIRequest request);
    }
}