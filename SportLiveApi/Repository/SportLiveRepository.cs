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
        }

        public async Task<List<Player>> GetPlayers()
        {
            return await _context.Players.ToListAsync();
        }

        public async Task<List<Player>> GetPlayersByTeamId(Guid teamId)
        {
            return await _context.Players.Where(p => p.TeamId == teamId).ToListAsync();
        }

        public async Task<Player> GetPlayerById(Guid playerId)
        {
            return await _context.Players.FirstOrDefaultAsync(p => p.Id == playerId);
        }

        public async Task<List<Team>> GetTeamsByGameId(Guid gameId)
        {
            var game = await _context.Games.FirstOrDefaultAsync(g => g.GameId == gameId);
            if (game == null)
            {
                return null;
            }

            return await _context.Teams.Where(t => game.TeamIds.Contains(t.Id)).ToListAsync();
        }

        public async Task<List<Game>> GetGamesByDate(DateTime date)
        {
            var games = await _context.Games.Where(g => g.GameDate.Date == date.Date).ToListAsync();
            return games;
        }

        public async Task<List<Event>> GetEventsByGameId(Guid gameId)
        {
            var events = await _context.Events.Where(e => e.GameId == gameId).ToListAsync();
            return events;
        }

        public async Task<List<Event>> GetEventByPlayerIdGameId(Guid gameId, Guid playerId)
        {
            var events = await _context.Events.Where(e => e.GameId == gameId && e.PlayerId == playerId).ToListAsync();
            return events;
        }

        public async Task<List<Event>> GetEventByTeamIdGameId(Guid gameId, Guid teamId)
        {
            var events = await _context.Events.Where(e => e.GameId == gameId && e.TeamId == teamId).ToListAsync();
            return events;
        }

        public async Task<Event> AddEvent(Event e)
        {
            await _context.Events.AddAsync(e);
            await _context.SaveChangesAsync();
            return e;
        }
    }
}