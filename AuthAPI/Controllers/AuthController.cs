using AuthAPI.Models.DTOs;
using AuthAPI.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthAPI.Controllers
{
    [Route("api/auth")]
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
            if(!string.IsNullOrEmpty(message))
            {
                _response.Success = false;
                _response.Message = message;
                return BadRequest(_response);
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
                return BadRequest(_response);
            }
            _response.Data = loginResponse;

            return Ok(_response);
        }
        [HttpPost("GiveRole")]
        public async Task<IActionResult> GiveRole([FromBody] RegisterRequestDTO requestDTO)
        {
            bool roleResponse = await _authService.GiveRole(requestDTO.Email, requestDTO.Role.ToUpper());
            if (!roleResponse)
            {
                _response.Success = false;
                _response.Message = "error";
                return BadRequest(_response);
            }

            return Ok(_response);
        }
    }
}
