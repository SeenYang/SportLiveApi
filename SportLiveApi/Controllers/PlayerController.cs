using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportLiveApi.Models.Entities;

namespace SportLiveApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class Player : ControllerBase
    {
        private SportLiveDbContext _context;

        public Player(SportLiveDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _context.Players.ToListAsync();
            return Ok(result);
        }
    }
}