using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SportLiveApi.Models;

namespace SportLiveApi.Repository
{
    public interface ISportLiveRepository
    {
        Task<List<Player>> GetPlayers();
        Task<List<Player>> GetPlayersByTeamId(Guid teamId);
        Task<Player> GetPlayerById(Guid playerId);
        Task<List<Team>> GetTeamsByGameId(Guid gameId);
        Task<List<Game>> GetGamesByDate(DateTime date);
        Task<List<Event>> GetEventsByGameId(Guid gameId);
        Task<List<Event>> GetEventByPlayerIdGameId(Guid gameId, Guid playerId);
        Task<List<Event>> GetEventByTeamIdGameId(Guid gameId, Guid teamId);
        Task<Event> AddEvent(Event e);
    }
}