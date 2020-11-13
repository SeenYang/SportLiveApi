using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SportLiveApi.Models
{
    public class SportLiveDbContext : DbContext
    {
        public SportLiveDbContext()
        {
        }

        public SportLiveDbContext(DbContextOptions<SportLiveDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Player> Players { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var teamId1 = Guid.NewGuid();
            modelBuilder.Entity<Player>().HasData(
                new List<Player>
                {
                    new Player
                    {
                        Id = Guid.NewGuid(),
                        FirstName = "First1",
                        LastName = "Last1",
                        Nickname = "Smart player",
                        Number = 23,
                        TeamId = teamId1
                    }
                }
            );
            base.OnModelCreating(modelBuilder);   
        }
    }

    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new SportLiveDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<SportLiveDbContext>>());
            // Look for any board games.
            if (context.Players.Any()) return; // Data was already seeded

            context.Players.AddRange(new List<Player>());

            context.SaveChanges();
        }
    }
}