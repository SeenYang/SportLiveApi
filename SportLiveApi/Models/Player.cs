﻿using System;
using System.Collections.Generic;

namespace SportLiveApi.Models.Entities
{
    public partial class Player
    {
        public Player()
        {
            
        }
        public Guid Id { get; set; }
        public Guid TeamId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public string Number { get; set; }
        public string PrimaryMarket { get; set; }
        public string BillingType { get; set; }
        public string JdeId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? ExternalModStamp { get; set; }
        public string AccountName { get; set; }

        public virtual Team PlayerToTeamNavigation { get; set; }
    }
}
