using CMS.APIServices.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Text.Unicode;

namespace CMS.APIServices
{
    public class APIBaseService : IAPIBaseService
    {
        public APIResponse APIResponse { get; set; }
        private readonly IHttpClientFactory httpClient;
        public APIBaseService(IHttpClientFactory httpClientFactory)
        {
            this.APIResponse = new APIResponse();
            this.httpClient = httpClientFactory;
        }

        public async Task<T> SendAsync<T>(APIRequest request)
        {
            try
            {
                var client= httpClient.CreateClient("ProductAPI");
                var message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri= new Uri(request.URL);
                if (request.Data != null)
                { 
                    message.Content= new StringContent(JsonConvert.SerializeObject(request.Data),Encoding.UTF8,"application/json");
                }
                switch (request.APIType) 
                {
                    case APIMethod.APIType.POST: 
                        message.Method=HttpMethod.Post; 
                        break;
                    case APIMethod.APIType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case APIMethod.APIType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                //var response= new HttpResponseMessage();
                var response= await client.SendAsync(message);

                var content= await response.Content.ReadAsStringAsync();
                var data=JsonConvert.DeserializeObject<T>(content);
                return data;
            }
            catch (Exception ex)
            {
                var model = new APIResponse()
                {
                    ErrorMessage = ex.Message,
                    Success=false,
                    StatusCode=500
                };
                var value= JsonConvert.SerializeObject(model);
                var data = JsonConvert.DeserializeObject<T>(value);
                return data;
            }
        }
    }
}
 