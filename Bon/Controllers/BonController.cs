using AutoMapper;
using BonAPI.Data;
using BonAPI.Models;
using BonAPI.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BonController : ControllerBase
    {
        private readonly DataContext _db;
        private readonly IMapper _mapper;
        private ApiResponse _response;
        public BonController(DataContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ApiResponse();
        }
        [HttpGet]
        public ApiResponse GetAll() {
            try
            {
                IEnumerable<Bon> bons = _db.Bons.Select(x => x).ToList();
                _response.Data = _mapper.Map<IEnumerable<BonDTO>>(bons);
            }
            catch(Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpGet]
        [Route("{id:int}")]
        public ApiResponse GetAll(int id)
        {
            try
            {
                var bon = _db.Bons.FirstOrDefault(x => x.Id == id);
                _response.Data = _mapper.Map<BonDTO>(bon);
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}
