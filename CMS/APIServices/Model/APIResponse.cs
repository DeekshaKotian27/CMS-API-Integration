namespace CMS.APIServices.Model
{
    public class APIResponse
    {
        public object Data {  get; set; }
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }

        public APIResponse SuccessMessage(int statusCode,object data=null)
        {
            return new APIResponse()
            {
                Success = true,
                StatusCode = statusCode,
                Data=data
            };
        }
        public APIResponse FailureMessage(int statusCode, string errorMessage)
        {
            return new APIResponse()
            {
                Success = false,
                StatusCode = statusCode,
                ErrorMessage= errorMessage
            };
        }
    }
    
}
