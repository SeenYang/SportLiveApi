using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportLiveApi.Repository;

namespace SportLiveApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class PlayerController : ControllerBase
    {
        private ISportLiveRepository _repo;

        public PlayerController(ISportLiveRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetPlayers()
        {
            var result = await _repo.GetPlayers();

            if (result.Count == 0)
            {
                return NotFound("No Player found.");
            }

            return Ok(result);
        }
        
        [HttpGet]
        [Route("GetPlayersByTeamId/{teamId}")]
        public async Task<IActionResult> GetPlayersByTeamId(Guid teamId)
        {
            var result = await _repo.GetPlayersByTeamId(teamId);

            if (result.Count == 0)
            {
                return NotFound("No Player found in this team.");
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("GetPlayerById/{playerId}")]
        public async Task<IActionResult> GetPlayerById(Guid palyerId)
        {
            var result = await _repo.GetPlayerById(palyerId);

            if (result == null)
            {
                return NotFound("Can not found this player.");
            }

            return Ok(result);
        }
    }
}