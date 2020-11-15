using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportLiveApi.Models;
using SportLiveApi.Models.Dtos;

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

        public async Task<List<PlayerDto>> GetPlayersByTeamId(Guid teamId)
        {
            var players = await _context.Players.Where(p => p.TeamId == teamId).Select(t => t.ToDto()).ToListAsync();
            return players;
        }

        public async Task<Player> GetPlayerById(Guid playerId)
        {
            return await _context.Players.FirstOrDefaultAsync(p => p.Id == playerId);
        }

        public async Task<List<Team>> GetTeamsByGameId(Guid gameId)
        {
            var teamIds = await _context.Games
                .Where(g => g.Id == gameId)
                .Select(g => g.TeamId)
                .ToListAsync();
            if (teamIds.Count == 0)
            {
                return null;
            }

            var teams = new List<Team>();
            foreach (var teamId in teamIds)
            {
                var team = await _context.Teams.FirstOrDefaultAsync(t => t.Id == teamId);
                if (team != null)
                {
                    teams.Add(team);
                }
            }

            return teams;
        }

        public async Task<List<GameDto>> GetGamesByDate(DateTime date)
        {
            var games = await _context.Games
                .Where(g => g.GameDate.Date == date.Date).ToListAsync();

            var groupedGames = games.GroupBy(t => t.Id).ToList();
            var gameDtos = groupedGames.Select(t => new GameDto
            {
                Id = t.Key,
                Date = t.First().GameDate,
                TeamIds = t.Select(tt => tt.TeamId).ToList()
            }).ToList();

            return gameDtos;
        }

        public async Task<GameDto> GetGamesById(Guid id)
        {
            // Get Game
            var games = await _context.Games
                .Where(g => g.Id == id).ToListAsync();

            var groupedGames = games.GroupBy(t => t.Id).ToList();
            var gameDto = groupedGames.Select(t => new GameDto
            {
                Id = t.Key,
                Date = t.First().GameDate,
                TeamIds = t.Select(tt => tt.TeamId).ToList()
            }).FirstOrDefault();

            if (gameDto == null)
            {
                return null;
            }
            
            // Get Teams
            var teams = await _context.Teams.Where(t => gameDto.TeamIds.Contains(t.Id)).ToListAsync();
            gameDto.TeamNames = teams.Select(t => t.Name).ToList();
            gameDto.Teams = teams.Select(t => t.ToDto()).ToList();

            // Get Players
            gameDto.Teams.ForEach(async t => { t.Players = await GetPlayersByTeamId(t.Id); });

            return gameDto;
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