using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SportLiveApi.Models;
using SportLiveApi.Repository;

namespace SportLiveApi.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class EventController : ControllerBase
    {
        private ISportLiveRepository _repo;

        public EventController(ISportLiveRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetEventsByGameId(Guid gameId)
        {
            var result = await _repo.GetEventsByGameId(gameId);

            if (result.Count == 0)
            {
                return NotFound("No event found for this game.");
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("GetEventByPlayerIdGameId/{gameId}/{playerId}")]
        public async Task<IActionResult> GetEventByPlayerIdGameId(Guid gameId, Guid playerId)
        {
            var result = await _repo.GetEventByPlayerIdGameId(gameId, playerId);

            if (result.Count == 0)
            {
                return NotFound("No event found for this player in game.");
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("GetEventByPlayerIdGameId/{gameId}/{teamId}")]
        public async Task<IActionResult> GetEventByTeamIdGameId(Guid gameId, Guid teamId)
        {
            var result = await _repo.GetEventByTeamIdGameId(gameId, teamId);

            if (result.Count == 0)
            {
                return NotFound("No event found for this player in game.");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddEvent([FromBody] Event e)
        {
            var result = await _repo.AddEvent(e);
            return Ok(result);
        }
    }
}