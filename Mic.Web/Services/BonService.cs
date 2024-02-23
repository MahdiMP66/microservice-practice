using BonAPI.Models.DTOs;
using Mic.Web.Models;
using Mic.Web.Services.IService;
using Mic.Web.Utility;

namespace Mic.Web.Services
{
    public class BonService : IBonService
    {
        private readonly IBaseService _baseService;

        public BonService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDTO?> AddAsync(BonDTO bonDTO)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                apiMethod = Statics.ApiMethod.POST,
                ApiUrl = Statics.BonApiBaseURL + "/api/bon",
                Data = bonDTO
            });
            
        }

        public async Task<ResponseDTO?> GetAllAsync()
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                apiMethod = Statics.ApiMethod.GET,
                ApiUrl = Statics.BonApiBaseURL + "/api/bon"
            });
        }

        public async Task<ResponseDTO?> GetByCodeAsync(int code)
        {
            return await _baseService.SendAsync(new RequestDTO
            {
                apiMethod = Statics.ApiMethod.GET,
                ApiUrl = Statics.BonApiBaseURL + "/api/bon/" + code
            });
        }

        public async Task<ResponseDTO?> GetSingleAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDTO
            {
                apiMethod = Statics.ApiMethod.GET,
                ApiUrl = Statics.BonApiBaseURL + "/api/bon/" + id
            });
        }

        public async Task<ResponseDTO?> RemoveAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDTO
            {
                apiMethod = Statics.ApiMethod.DELETE,
                ApiUrl = Statics.BonApiBaseURL + "/api/bon/" +id
            });
        }

        public async Task<ResponseDTO?> UpdateAsync(BonDTO bonDTO)
        {
            return await _baseService.SendAsync(new RequestDTO
            {
                apiMethod = Statics.ApiMethod.PUT,
                Data = bonDTO,
                ApiUrl = Statics.BonApiBaseURL + "/api/bon"
            });
        }
    }
}
