using Mic.Web.Models;

namespace Mic.Web.Services.IService
{
    public interface IAuthService
    {
        Task<ResponseDTO?> Login(LoginRequestDTO request);
        Task<ResponseDTO?> Register(RegisterRequestDTO request);
        Task<ResponseDTO?> GiveRole(RegisterRequestDTO request);
    }
}
