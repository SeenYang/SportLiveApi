using System;

namespace SportLiveApi.Models.Dtos
{
    public class PlayerDto
    {
        public Guid Id { get; set; }
        public Guid TeamId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public int Number { get; set; }
    }
}