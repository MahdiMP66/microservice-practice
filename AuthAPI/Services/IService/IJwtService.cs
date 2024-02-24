using AuthAPI.Models;

namespace AuthAPI.Services.IService
{
    public interface IJwtService
    {
        string GenerateToken(AppUser user);
    }
}
