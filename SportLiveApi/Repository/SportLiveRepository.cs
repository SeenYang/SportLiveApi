using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportLiveApi.Models;

namespace SportLiveApi.Repository
{
    public class SportLiveRepository : ISportLiveRepository
    {
        private readonly SportLiveDbContext _context;

        public SportLiveRepository(SportLiveDbContext context)
        {
            _context = context;
            // SeedingInMemoryDB(_context);
        }

        private void SeedingInMemoryDB(SportLiveDbContext context)
        {
            var teamId1 = Guid.NewGuid();
            var teamId2 = Guid.NewGuid();
            if (context.Players.FirstOrDefault() == null)
            {
                context.Players.AddRange(new List<Player>
                {
                    new Player
                    {
                        FirstName = "First1",
                        LastName = "Last1",
                        Nickname = "Smart player",
                        Number = 23,
                        TeamId = teamId1
                    }
                });
            }

            _context.SaveChanges();
        }

        public async Task<List<Player>> GetPlayerByTeamId(Guid teamId)
        {
            return await _context.Players.ToListAsync();
        }
    }
}