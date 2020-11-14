using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportLiveApi.Models
{
    public class Game
    {
        public Guid GameId { get; set; }
        public Guid TeamId { get; set; }
        public DateTime GameDate { get; set; }
    }
}