using Mic.Web.Models;
using Mic.Web.Services.IService;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using static Mic.Web.Utility.Statics;

namespace Mic.Web.Services
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ResponseDTO?> SendAsync(RequestDTO requestDTO)
        {
            try
            {
                var clinet = _httpClientFactory.CreateClient("ApiClient");
                HttpRequestMessage message = new();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(requestDTO.ApiUrl);
                if (requestDTO.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(requestDTO)
                        , Encoding.UTF8, "application/json");
                }
                HttpResponseMessage? apiResponse = null;

                switch (requestDTO.apiMethod)
                {
                    case ApiMethod.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case ApiMethod.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case ApiMethod.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }
                apiResponse = await clinet.SendAsync(message);
                switch (apiResponse.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new() { Success = false, Message = "Not Found" };
                    case HttpStatusCode.Forbidden:
                        return new() { Success = false, Message = "Access denied" };
                    case HttpStatusCode.InternalServerError:
                        return new() { Success = false, Message = "Server error" };
                    default:
                        var apiContent = await apiResponse.Content.ReadAsStringAsync();
                        var responseDto = JsonConvert.DeserializeObject<ResponseDTO>(apiContent);
                        return responseDto;
                }
            }
            catch (Exception ex)
            {
                return new() { Success = false, Message = ex.Message };
            }
        }
    }
}
