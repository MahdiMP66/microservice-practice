using AuthAPI.Data;
using AuthAPI.Models;
using AuthAPI.Models.DTOs;
using AuthAPI.Services.IService;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;

namespace AuthAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _db;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public AuthService(DataContext db,RoleManager<IdentityRole> roleManager,UserManager<AppUser> userManager)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<UserDTO> Register(RegisterRequestDTO requestDTO)
        {
            var user = new AppUser()
            {
                Email = requestDTO.Email,
                NormalizedEmail = requestDTO.Email.ToUpper(),
                Name = requestDTO.Name,
                UserName = requestDTO.Email
            };

            try
            {
                var result = await _userManager.CreateAsync(user, requestDTO.Password);
                if (result.Succeeded)
                {
                    var dbUser = _db.Users.FirstOrDefault(user => user.Email == requestDTO.Email);
                    UserDTO userDTO = new UserDTO()
                    {
                        Username = dbUser.Email,
                        Email = dbUser.Email,
                        Id = dbUser.Id,
                        PhoneNumber = dbUser.PhoneNumber
                    };
                    return userDTO;
                }
                else
                {
                    return new UserDTO();
                }
            }
            catch (Exception ex)
            {

            }
            return new UserDTO();
        }


        public async Task<LoginResponseDTO> Login(LoginRequestDTO requestDTO)
        {
            var user = _db.Users.FirstOrDefault(u => u.UserName.ToLower() == requestDTO.Username.ToLower());
            bool isValidUser = await _userManager.CheckPasswordAsync(user, requestDTO.Password);
            if (user== null || !isValidUser)
            {
                return new() { Token = "", User = null };
            }
            UserDTO userDTO = new()
            {
                Username = user.UserName,
                Id = user.Id,
                Email=user.Email,
                PhoneNumber = user.PhoneNumber
            };
            return new() { Token="", User=userDTO };
        }

    }
}
