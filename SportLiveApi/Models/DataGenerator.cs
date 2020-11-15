using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SportLiveApi.Models
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new SportLiveDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<SportLiveDbContext>>());

            var teamId1 = Guid.NewGuid();
            var teamId2 = Guid.NewGuid();
            var gameId1 = Guid.NewGuid();
            var gameId2 = Guid.NewGuid();


            if (context.Players.Any())
            {
                return; // Database has been seeded
            }

            context.Players.AddRange(
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "First1",
                    LastName = "Last1",
                    Nickname = "Smart player",
                    Number = 23,
                    TeamId = teamId1
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "First2",
                    LastName = "Last2",
                    Nickname = "Pretty player",
                    Number = 12,
                    TeamId = teamId1
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "First3",
                    LastName = "Last3",
                    Nickname = "Smart player",
                    Number = 8,
                    TeamId = teamId1
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "First4",
                    LastName = "Last4",
                    Nickname = "Smart player",
                    Number = 65,
                    TeamId = teamId1
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "First5",
                    LastName = "Last5",
                    Nickname = "Smart player",
                    Number = 98,
                    TeamId = teamId1
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "First6",
                    LastName = "Last6",
                    Nickname = "Smart player",
                    Number = 23,
                    TeamId = teamId2
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "First7",
                    LastName = "Last7",
                    Nickname = "Smart player",
                    Number = 11,
                    TeamId = teamId2
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "First8",
                    LastName = "Last8",
                    Nickname = "Smart player",
                    Number = 97,
                    TeamId = teamId2
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "First9",
                    LastName = "Last9",
                    Nickname = "Smart player",
                    Number = 87,
                    TeamId = teamId2
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "First10",
                    LastName = "Last10",
                    Nickname = "Smart player",
                    Number = 26,
                    TeamId = teamId2
                }
            );

            context.Teams.AddRange(
                new Team
                {
                    Id = teamId1,
                    Name = "ThunderBolt3",
                    Logo = "logo/tb3.jpg"
                },
                new Team
                {
                    Id = teamId2,
                    Name = "Dear Bear",
                    Logo = "logo/db.jpg"
                }
            );


            context.Games.AddRange(
                new Game
                {
                    Id = gameId1,
                    GameDate = DateTime.Now.AddHours(4),
                    TeamId = teamId1,
                },
                new Game
                {
                    Id = gameId1,
                    GameDate = DateTime.Now.AddHours(4),
                    TeamId = teamId2,
                }, new Game
                {
                    Id = gameId2,
                    GameDate = DateTime.Now.AddHours(6),
                    TeamId = teamId1,
                },
                new Game
                {
                    Id = gameId2,
                    GameDate = DateTime.Now.AddHours(6),
                    TeamId = teamId2,
                }
            );

            context.SaveChanges();
        }
    }
}