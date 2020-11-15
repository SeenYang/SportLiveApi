using System;
using System.Collections.Generic;
using SportLiveApi.Models.Dtos;

namespace SportLiveApi.Models
{
    public class Team
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }

        public TeamDto ToDto()
        {
            return new TeamDto
            {
                Id = Id,
                Logo =  Logo,
                Name =  Name,
                Players = new List<PlayerDto>()
            };
        }
    }
}