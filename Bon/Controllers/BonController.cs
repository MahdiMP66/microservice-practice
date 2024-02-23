using AutoMapper;
using BonAPI.Data;
using BonAPI.Models;
using BonAPI.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BonController : ControllerBase
    {
        private readonly DataContext _db;
        private readonly IMapper _mapper;
        private ResponseDTO _response;
        public BonController(DataContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDTO();
        }
        [HttpGet]
        public ResponseDTO GetAll()
        {
            try
            {
                IEnumerable<Bon> bons = _db.Bons.Select(x => x).ToList();
                _response.Data = _mapper.Map<IEnumerable<BonDTO>>(bons);
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpGet]
        [Route("{id:int}")]
        public ResponseDTO GetSingle(int id)
        {
            try
            {
                var bon = _db.Bons.First(x => x.Id == id);
                _response.Data = _mapper.Map<BonDTO>(bon);
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpGet]
        [Route("GetByCode/{code:int}")]
        public ResponseDTO GetByCode(int code)
        {
            try
            {
                var bon = _db.Bons.First(x => x.Code == code);
                _response.Data = _mapper.Map<BonDTO>(bon);
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpPost]
        public ResponseDTO AddBon([FromBody] BonDTO bonDTO)
        {
            try
            {
                Bon bon = _mapper.Map<Bon>(bonDTO);
                _db.Bons.Add(bon);
                _db.SaveChanges();
                _response.Data = _mapper.Map<BonDTO>(bon);
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpPut]
        public ResponseDTO UpdateBon([FromBody] BonDTO bonDTO)
        {
            try
            {
                Bon bon = _mapper.Map<Bon>(bonDTO);
                _db.Bons.Update(bon);
                _db.SaveChanges();
                _response.Data = _mapper.Map<BonDTO>(bon);
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpDelete]
        [Route("{id:int}")]
        public ResponseDTO DeleteBon(int id)
        {
            try
            {
                var bon = _db.Bons.First(x => x.Id == id);
                _db.Bons.Remove(bon);
                _db.SaveChanges();
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
