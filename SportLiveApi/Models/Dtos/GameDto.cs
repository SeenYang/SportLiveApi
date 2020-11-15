using System;
using System.Collections.Generic;

namespace SportLiveApi.Models.Dtos
{
    public class GameDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public List<string> TeamNames { get; set; }
        public List<Guid> TeamIds { get; set; }
        public List<TeamDto> Teams { get; set; }
    }
}