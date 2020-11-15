using System;
using System.Linq;
using System.Threading.Tasks;
using SportLiveApi.Models;
using SportLiveApi.Models.Dtos;
using SportLiveApi.Repository;

namespace SportLiveApi.Services
{
    public class GameServices : IGameServices
    {
        private ISportLiveRepository _repository;

        public GameServices(ISportLiveRepository repository)
        {
            _repository = repository;
        }
    }
}