using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SportLiveApi.Models
{
    public class SportLiveDbContext : DbContext
    {
        public SportLiveDbContext(DbContextOptions<SportLiveDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Player> Players { get; set; }
    }
}