using System;
using SportLiveApi.Models.Dtos;

namespace SportLiveApi.Models
{
    public class Player
    {
        public Guid Id { get; set; }
        public Guid TeamId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public int Number { get; set; }

        public PlayerDto ToDto()
        {
            return new PlayerDto
            {
                Id = Id,
                TeamId = TeamId,
                FirstName = FirstName,
                LastName = LastName,
                Nickname = Nickname,
                Number = Number
            };
        }
    }
}