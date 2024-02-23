using AuthAPI.Models.DTOs;
using AuthAPI.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        
        private ResponseDTO _response;
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _response = new ResponseDTO();
            _authService = authService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO requestDTO)
        {
            var message = await _authService.Register(requestDTO);
            if(message.Username == null)
            {
                return BadRequest("error creating user!"); // if any conditions fail, this error will be encounterd(not good approach)
            }
            return Ok(_response);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO requestDTO)
        {
            var loginResponse = await _authService.Login(requestDTO);
            if(loginResponse.User == null)
            {
                _response.Success = false;
                _response.Message = "user or pass incorrect"; 
            }
            _response.Data = loginResponse;

            return Ok(_response);
        }
    }
}
