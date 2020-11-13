using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportLiveApi.Models;
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
        public async Task<IActionResult> Get()
        {
            var result = await _repo.GetPlayerByTeamId(Guid.NewGuid());

            if (result.Count == 0)
            {
                return NotFound("No Player found in this team.");
            }

            return Ok(result);
        }
    }
}