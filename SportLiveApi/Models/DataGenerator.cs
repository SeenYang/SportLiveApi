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
            using (var context = new SportLiveDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<SportLiveDbContext>>()))
            {
                var teamId1 = Guid.NewGuid();
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
                    }
                );

                context.SaveChanges();
            }
        }
    }
}