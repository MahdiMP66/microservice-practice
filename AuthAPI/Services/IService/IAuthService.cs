using AuthAPI.Models.DTOs;

namespace AuthAPI.Services.IService
{
    public interface IAuthService
    {
        Task<UserDTO> Register(RegisterRequestDTO requestDTO);
        Task<LoginResponseDTO> Login(LoginRequestDTO requestDTO);
    }
}
