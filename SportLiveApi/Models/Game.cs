using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SportLiveApi.Models.Dtos;

namespace SportLiveApi.Models
{
    public class Game
    {
        public Guid Id { get; set; }
        public Guid TeamId { get; set; }
        public DateTime GameDate { get; set; }

        public GameDto ToDto()
        {
            return new GameDto
            {
                Id = Id,
                Date = GameDate,
                Teams = new List<TeamDto>()
            };
        }
    }
}