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
                TempData["success"] = "bon created!";
                return RedirectToAction(nameof(BonIndex));
            }
            return View(bonDTO);
        }

        public async Task<IActionResult> BonDelete(int bonId)
        {
            ResponseDTO response = await _bonService.GetSingleAsync(bonId);
            if( response != null && response.Success)
            { 
                BonDTO bon = JsonConvert.DeserializeObject<BonDTO>(Convert
                    .ToString(response.Data));
                
                return View(bon);
            }
            return NotFound();
            
        }

        [HttpPost]
        public async Task<IActionResult> BonDelete(BonDTO bonDTO)
        {
            ResponseDTO? responseDTO = await _bonService.RemoveAsync(bonDTO.Id);
            if( responseDTO != null && responseDTO.Success)
            {
                TempData["success"] = "bon deleted!";
                return RedirectToAction(nameof(BonIndex));
            }
            return View(bonDTO);
        }
    }
}
