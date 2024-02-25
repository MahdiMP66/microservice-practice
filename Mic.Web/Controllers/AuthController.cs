using Mic.Web.Services.IService;
using Microsoft.AspNetCore.Mvc;

namespace Mic.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
           _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
