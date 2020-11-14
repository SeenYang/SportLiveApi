using System;
using System.Collections.Generic;

namespace SportLiveApi.Models
{
    public class Game
    {
        public Guid GameId { get; set; }
        public List<Guid> TeamIds { get; set; }
        public DateTime GameDate { get; set; }
    }
}