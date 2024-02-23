using BonAPI.Models.DTOs;
using Mic.Web.Models;

namespace Mic.Web.Services.IService
{
    public interface IBonService
    {
        Task<ResponseDTO?> GetAllAsync();
        Task<ResponseDTO?> GetSingleAsync(int id);
        Task<ResponseDTO?> GetByCodeAsync(int code);
        Task<ResponseDTO?> AddAsync(BonDTO bonDTO);
        Task<ResponseDTO?> UpdateAsync(BonDTO bonDTO);
        Task<ResponseDTO?> RemoveAsync(int id);
       


    }
}
