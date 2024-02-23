using static Mic.Web.Utility.Statics;

namespace Mic.Web.Models
{
    public class RequestDTO
    {
        public ApiMethod apiMethod { get; set; } = ApiMethod.GET;
        public string ApiUrl { get; set;}
        public object Data { get; set; }
        public string Token { get; set; }
    }
}
