using BonAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BonController : ControllerBase
    {
        private readonly DataContext _db;

        public BonController(DataContext db)
        {
            _db = db;
        }

    }
}
