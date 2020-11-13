using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SportLiveApi.Models.Entities
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
            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasOne(d => d.PlayerToTeamNavigation)
                    .WithMany(p => p.Player)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }

    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new SportLiveDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<SportLiveDbContext>>());
            // Look for any board games.
            if (context.Players.Any())
            {
                return; // Data was already seeded
            }

            context.Players.AddRange(new List<Player>());

            context.SaveChanges();
        }
    }
}