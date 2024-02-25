using Mic.Web.Models;
using Mic.Web.Services.IService;
using Mic.Web.Utility;

namespace Mic.Web.Services
{
    public class AuthService : IAuthService
    {
        private readonly IBaseService _baseService;

        public AuthService(IBaseService baseService)
        {
            _baseService = baseService;
        }


        public async Task<ResponseDTO?> GiveRole(RegisterRequestDTO request)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                apiMethod = Statics.ApiMethod.POST,
                ApiUrl = Statics.AuthApiBaseURL + "api/auth/GiveRole",
                Data = request,

            });
        }

        public async Task<ResponseDTO?> Login(LoginRequestDTO request)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                apiMethod = Statics.ApiMethod.POST,
                ApiUrl = Statics.AuthApiBaseURL + "api/auth/login",
                Data = request,

            });
        }

        public async Task<ResponseDTO?> Register(RegisterRequestDTO request)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                apiMethod = Statics.ApiMethod.POST,
                ApiUrl = Statics.AuthApiBaseURL + "api/auth/register",
                Data = request,

            });
        }
    }
}
