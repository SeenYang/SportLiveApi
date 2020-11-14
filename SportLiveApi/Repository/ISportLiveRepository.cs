using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SportLiveApi.Models;

namespace SportLiveApi.Repository
{
    public interface ISportLiveRepository
    {
        Task<List<Player>> GetPlayersByTeamId(Guid teamId);

    }
}