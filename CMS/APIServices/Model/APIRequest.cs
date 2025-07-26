using static CMS.APIServices.Model.APIMethod;

namespace CMS.APIServices.Model
{
    public class APIRequest
    {
        public APIType APIType { get; set; } = APIType.GET;
        public string URL { get; set; }
        public object Data { get; set; }
    }
}