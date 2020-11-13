﻿using System;
using System.Collections.Generic;

namespace SportLiveApi.Models.Entities
{
    public partial class Team
    {
        public Team()
        {
            Player = new HashSet<Player>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        
        public virtual ICollection<Player> Player { get; set; }
    }
}
