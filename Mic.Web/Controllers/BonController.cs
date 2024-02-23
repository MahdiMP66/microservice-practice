using BonAPI.Models.DTOs;
using Mic.Web.Models;
using Mic.Web.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mic.Web.Controllers
{
    public class BonController : Controller
    {
        private readonly IBonService _bonService;

        public BonController(IBonService bonService)
        {
            _bonService = bonService;
        }
        public async Task<IActionResult> BonIndex()
        {
            List<BonDTO>?  bonDTOs = null;
            ResponseDTO? apiResponse = await _bonService.GetAllAsync();
            if (apiResponse != null && apiResponse.Success)
            {
                bonDTOs = JsonConvert
                    .DeserializeObject<List<BonDTO>>(Convert.ToString(apiResponse.Data));
            }
            return View(bonDTOs);
        }
        public async Task<IActionResult> BonCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BonCreate(BonDTO bonDTO)
        {
            ResponseDTO? response = await _bonService.AddAsync(bonDTO);
            if(response != null && response.Success) 
            { 
                return RedirectToAction(nameof(BonIndex));
            }
            return View(bonDTO);
        }
    }
}
