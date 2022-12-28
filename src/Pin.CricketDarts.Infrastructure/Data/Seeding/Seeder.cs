using Microsoft.EntityFrameworkCore;
using Pin.CricketDarts.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Pin.CricketDarts.Infrastructure.Data.Seeding
{
    public class Seeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            Random rnd = new Random();

            List<Player> players = new List<Player>
            {
                new Player { Id = Guid.NewGuid(), Name = "VincentVega", PersonalStatisticsId =  new Guid("59062baa-5af2-483d-a683-8f982252a3d9") },
                new Player { Id = Guid.NewGuid(), Name = "BruceWillis", PersonalStatisticsId =  new Guid("fcf8914b-061f-4e1c-af01-9fbb8f0847e9") },
                new Player { Id = Guid.NewGuid(), Name = "Fabienne", PersonalStatisticsId =  new Guid("0928ac0b-b2f6-4189-9280-2318c8ab91d2") },
                new Player { Id = Guid.NewGuid(), Name = "Butch", PersonalStatisticsId =  new Guid("fd89d57c-01ea-4938-9061-4961c3ed02dc") },
                new Player { Id = Guid.NewGuid(), Name = "JohnTravolta", PersonalStatisticsId =  new Guid("1389d5cd-2fa1-4dfd-a422-c4e30e89686e") },
                new Player { Id = Guid.NewGuid(), Name = "TheWolf", PersonalStatisticsId =  new Guid("f49ac80b-e798-4ae6-8689-2016921e6a64") }
            };


            List<PersonalStatistics> personalStatistics = new List<PersonalStatistics>
            {
                new PersonalStatistics { Id = new Guid("59062baa-5af2-483d-a683-8f982252a3d9"), DoublesThrown = 2, GamesLost = 2, GamesWon= 4, TriplesThrown = 3 },
                new PersonalStatistics { Id = new Guid("fcf8914b-061f-4e1c-af01-9fbb8f0847e9"), DoublesThrown = 53, GamesLost = 6, GamesWon = 22, TriplesThrown = 22 },
                new PersonalStatistics { Id = new Guid("0928ac0b-b2f6-4189-9280-2318c8ab91d2"), DoublesThrown = 52, GamesLost = 34, GamesWon= 6, TriplesThrown = 45 },
                new PersonalStatistics { Id = new Guid("fd89d57c-01ea-4938-9061-4961c3ed02dc"), DoublesThrown = 53, GamesLost = 56, GamesWon = 4, TriplesThrown = 7 },
                new PersonalStatistics { Id = new Guid("1389d5cd-2fa1-4dfd-a422-c4e30e89686e"), DoublesThrown = 22, GamesLost = 25, GamesWon= 77, TriplesThrown = 6 },
                new PersonalStatistics { Id = new Guid("f49ac80b-e798-4ae6-8689-2016921e6a64"), DoublesThrown = 33, GamesLost = 12, GamesWon = 4, TriplesThrown = 33 }
            };

            List<Game> games = new List<Game>
            {
                new Game{ Id = Guid.NewGuid(),  ActiveGame = false, WinnerId = players[0].Id },
                new Game{ Id = Guid.NewGuid(),  ActiveGame = false, WinnerId = players[1].Id },
                new Game{ Id = Guid.NewGuid(),  ActiveGame = false, WinnerId = players[2].Id },
                new Game{ Id = Guid.NewGuid(),  ActiveGame = false, WinnerId = players[3].Id },
                new Game{ Id = Guid.NewGuid(),  ActiveGame = false, WinnerId = players[4].Id },
                new Game{ Id = Guid.NewGuid(),  ActiveGame = false, WinnerId = players[5].Id }
            };

            List<PlayerGames> playerGames = new List<PlayerGames>
            {
                new PlayerGames{ GameId = games[0].Id, PlayerId = players[0].Id },
                new PlayerGames{ GameId = games[0].Id, PlayerId = players[1].Id },
                new PlayerGames{ GameId = games[1].Id, PlayerId = players[2].Id },
                new PlayerGames{ GameId = games[1].Id, PlayerId = players[3].Id },
                new PlayerGames{ GameId = games[2].Id, PlayerId = players[4].Id },
                new PlayerGames{ GameId = games[2].Id, PlayerId = players[5].Id }
            };


            List<Score> scores = new List<Score>
            {
                new Score { Id = Guid.NewGuid(), PlayerId = players[0].Id, TotalScore = 20, GameId = games[0].Id },
                new Score { Id = Guid.NewGuid(), PlayerId = players[1].Id, TotalScore = 40, GameId = games[0].Id },
                new Score { Id = Guid.NewGuid(), PlayerId = players[2].Id, TotalScore = 2, GameId = games[1].Id  },
                new Score { Id = Guid.NewGuid(), PlayerId = players[3].Id, TotalScore = 33, GameId = games[1].Id },
                new Score { Id = Guid.NewGuid(), PlayerId = players[4].Id, TotalScore = 54, GameId = games[2].Id },
                new Score { Id = Guid.NewGuid(), PlayerId = players[5].Id, TotalScore = 4, GameId = games[2].Id }
            };

            modelBuilder.Entity<Player>().HasData(players);
            modelBuilder.Entity<PersonalStatistics>().HasData(personalStatistics);
            modelBuilder.Entity<Game>().HasData(games);
            modelBuilder.Entity<PlayerGames>().HasData(playerGames);
            modelBuilder.Entity<Score>().HasData(scores);
        }
    }
}
