using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SportLiveApi.Models;
using SportLiveApi.Models.Dtos;

namespace SportLiveApi.Repository
{
    public interface ISportLiveRepository
    {
        Task<List<Player>> GetPlayers();
        Task<List<PlayerDto>> GetPlayersByTeamId(Guid teamId);
        Task<Player> GetPlayerById(Guid playerId);
        Task<List<Team>> GetTeamsByGameId(Guid gameId);
        Task<List<GameDto>> GetGamesByDate(DateTime date);
        Task<GameDto> GetGamesById(Guid id);
        Task<List<Event>> GetEventsByGameId(Guid gameId);
        Task<List<Event>> GetEventByPlayerIdGameId(Guid gameId, Guid playerId);
        Task<List<Event>> GetEventByTeamIdGameId(Guid gameId, Guid teamId);
        Task<Event> AddEvent(Event e);
    }
}