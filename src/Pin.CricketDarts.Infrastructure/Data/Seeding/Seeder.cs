using Microsoft.EntityFrameworkCore;
using Pin.CricketDarts.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.CricketDarts.Infrastructure.Data.Seeding
{
    public class Seeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            Random rnd = new Random();

            List<PersonalStatistics> personalStatistics = new List<PersonalStatistics>
            {
                new PersonalStatistics { Id = Guid.NewGuid(), DoublesThrown = 2, GamesLost = 2, GamesWon= 4, TriplesThrown = 3 },
                new PersonalStatistics { Id = Guid.NewGuid(), DoublesThrown = 53, GamesLost = 6, GamesWon = 22, TriplesThrown = 22 },
                new PersonalStatistics { Id = Guid.NewGuid(), DoublesThrown = 52, GamesLost = 34, GamesWon= 6, TriplesThrown = 45 },
                new PersonalStatistics { Id = Guid.NewGuid(), DoublesThrown = 53, GamesLost = 56, GamesWon = 4, TriplesThrown = 7 },
                new PersonalStatistics { Id = Guid.NewGuid(), DoublesThrown = 22, GamesLost = 25, GamesWon= 77, TriplesThrown = 6 },
                new PersonalStatistics { Id = Guid.NewGuid(), DoublesThrown = 33, GamesLost = 12, GamesWon = 4, TriplesThrown = 33 }
            };

            List<Player> players = new List<Player>
            {
                new Player { Id = Guid.NewGuid(), Name = "VincentVega", PersonalStatisticsId =  personalStatistics[0].Id },
                new Player { Id = Guid.NewGuid(), Name = "BruceWillis", PersonalStatisticsId =  personalStatistics[1].Id },
                new Player { Id = Guid.NewGuid(), Name = "Fabienne", PersonalStatisticsId =  personalStatistics[2].Id },
                new Player { Id = Guid.NewGuid(), Name = "Butch", PersonalStatisticsId =  personalStatistics[3].Id },
                new Player { Id = Guid.NewGuid(), Name = "JohnTravolta", PersonalStatisticsId =  personalStatistics[4].Id },
                new Player { Id = Guid.NewGuid(), Name = "TheWolf", PersonalStatisticsId =  personalStatistics[5].Id }
            };

            List<Game> games = new List<Game>
            {
                new Game{ Id = Guid.NewGuid(),  ActiveGame = false, Players = players.OrderBy(p => rnd.Next()).Take(2).ToList() },
                new Game{ Id = Guid.NewGuid(),  ActiveGame = false, Players = players.OrderBy(p => rnd.Next()).Take(2).ToList() },
                new Game{ Id = Guid.NewGuid(),  ActiveGame = false, Players = players.OrderBy(p => rnd.Next()).Take(2).ToList() },
                new Game{ Id = Guid.NewGuid(),  ActiveGame = false, Players = players.OrderBy(p => rnd.Next()).Take(2).ToList() }
            };

            List<Score> scores = new List<Score>
            {
                new Score { Id = Guid.NewGuid(), PlayerId = games[0].Players.ToList()[0].Id, TotalScore = 20 },
                new Score { Id = Guid.NewGuid(), PlayerId = games[0].Players.ToList()[1].Id, TotalScore = 40 },
                new Score { Id = Guid.NewGuid(), PlayerId = games[1].Players.ToList()[0].Id, TotalScore = 2 },
                new Score { Id = Guid.NewGuid(), PlayerId = games[1].Players.ToList()[1].Id, TotalScore = 33 },
                new Score { Id = Guid.NewGuid(), PlayerId = games[2].Players.ToList()[0].Id, TotalScore = 54 },
                new Score { Id = Guid.NewGuid(), PlayerId = games[2].Players.ToList()[1].Id, TotalScore = 4 },
                new Score { Id = Guid.NewGuid(), PlayerId = games[3].Players.ToList()[0].Id, TotalScore = 24 },
                new Score { Id = Guid.NewGuid(), PlayerId = games[3].Players.ToList()[1].Id, TotalScore = 32 }
            };

            modelBuilder.Entity<PersonalStatistics>().HasData(personalStatistics);
            modelBuilder.Entity<Player>().HasData(players);
            modelBuilder.Entity<Game>().HasData(games);
            modelBuilder.Entity<Score>().HasData(scores);
        }
    }
}
