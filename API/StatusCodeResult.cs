using API.Model;
using Microsoft.AspNetCore.Mvc;

namespace API
{
    public static class StatusCodeResult
    {
        public static ObjectResult GetStatusCode(APIResponse response)
        {
            var data = new ObjectResult(response)
            { 
                StatusCode = response.StatusCode 
            };
            
            return data;
        }
    }
}
