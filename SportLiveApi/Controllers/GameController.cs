using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportLiveApi.Repository;

namespace SportLiveApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class GameController: ControllerBase
    {
        private ISportLiveRepository _repo;

        public GameController(ISportLiveRepository repo)
        {
            _repo = repo;
        }
        
        [HttpGet]
        [Route("GetTeamsByGameId/{gameId}")]
        public async Task<IActionResult> GetTeamsByGameId(Guid gameId)
        {
            var result = await _repo.GetTeamsByGameId(gameId);

            if (result.Count == 0)
            {
                return NotFound("No Teams found.");
            }

            return Ok(result);
        }        
        [HttpGet]
        [Route("GetGamesByDate/{dateStr}")]
        public async Task<IActionResult> GetGamesByDate(string dateStr)
        {
            try
            {
                DateTime.TryParse(dateStr, out var date);
                var result = await _repo.GetGamesByDate(date);
                if (result.Count == 0)
                {
                    return NotFound("No game found for provided date.");
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest("Invalid date.");
            }

        }

    }
}