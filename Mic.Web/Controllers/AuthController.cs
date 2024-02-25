using Mic.Web.Models;
using Mic.Web.Services.IService;
using Mic.Web.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Mic.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
           _authService = authService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            var roles = new List<SelectListItem>() 
            { 
                new SelectListItem() {Text="Admin",Value=Statics.Role_Admin  },
                new SelectListItem() {Text="Customer",Value=Statics.Role_Customer  }
            };
            ViewBag.Roles = roles;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequestDTO requestDTO)
        {
            ResponseDTO response = await _authService.Register(requestDTO);
            ResponseDTO roleResponse;
            if (response != null && response.Success)
            {
                if (string.IsNullOrEmpty(requestDTO.Role))
                {
                    requestDTO.Role = Statics.Role_Customer;
                }
                roleResponse = await _authService.GiveRole(requestDTO);
                if(roleResponse != null && roleResponse.Success)
                {
                    TempData["success"] = "Registered Successfully";
                    return RedirectToAction("Index", "Home");
                }
                
            }
            //if there was an error, have the roles in viewbag
            var roles = new List<SelectListItem>()
            {
                new SelectListItem() {Text="Admin",Value=Statics.Role_Admin  },
                new SelectListItem() {Text="Customer",Value=Statics.Role_Customer  }
            };
            ViewBag.Roles = roles;
            return View();
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDTO requestDTO)
        {
            ResponseDTO response = await _authService.Login(requestDTO);

            if (response != null && response.Success)
            {
                LoginResponseDTO responseDTO = JsonConvert.DeserializeObject<LoginResponseDTO>(Convert.ToString(response.Data));
                TempData["success"] = "Logged in Successfully";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("error", response.Message);
                return View(requestDTO);
            }
        }

    }
}
