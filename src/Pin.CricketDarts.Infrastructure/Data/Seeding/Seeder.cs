using Microsoft.EntityFrameworkCore;
using Pin.CricketDarts.Core.Entities;
using Pin.CricketDarts.Core.Enums;
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

            List<Tournament> tournaments = new List<Tournament>
            {
                new Tournament{ Id = new Guid("243407c9-d7e6-4192-a465-71076a592bf9") }
            };

            List<Player> players = new List<Player>
            {
                new Player { Id = Guid.NewGuid(), Name = "VincentVega"  },
                new Player { Id = Guid.NewGuid(), Name = "BruceWillis" },
                new Player { Id = Guid.NewGuid(), Name = "Fabienne" },
                new Player { Id = Guid.NewGuid(), Name = "Butch" },
                new Player { Id = Guid.NewGuid(), Name = "JohnTravolta" },
                new Player { Id = Guid.NewGuid(), Name = "TheWolf" }
            };

            List<Game> games = new List<Game>
            {
                new Game{ Id = Guid.NewGuid(),  IsActive = false, WinnerId = players[0].Id, TournamentId = new Guid("243407c9-d7e6-4192-a465-71076a592bf9") },
                new Game{ Id = Guid.NewGuid(),  IsActive = false, WinnerId = players[1].Id, TournamentId = new Guid("243407c9-d7e6-4192-a465-71076a592bf9") },
                new Game{ Id = Guid.NewGuid(),  IsActive = false, WinnerId = players[2].Id, TournamentId = new Guid("243407c9-d7e6-4192-a465-71076a592bf9") },
                new Game{ Id = Guid.NewGuid(),  IsActive = false, WinnerId = players[3].Id, TournamentId = new Guid("243407c9-d7e6-4192-a465-71076a592bf9") },
                new Game{ Id = Guid.NewGuid(),  IsActive = false, WinnerId = players[4].Id, TournamentId = new Guid("243407c9-d7e6-4192-a465-71076a592bf9") },
                new Game{ Id = Guid.NewGuid(),  IsActive = true, CurrentTurnId = new Guid("3226B169-0211-4235-9AFD-869B8B79C05E"), TournamentId = new Guid("243407c9-d7e6-4192-a465-71076a592bf9") }
            };

            List<PlayerGames> playerGames = new List<PlayerGames>
            {
                new PlayerGames{ GameId = games[5].Id, PlayerId = players[0].Id },
                new PlayerGames{ GameId = games[5].Id, PlayerId = players[1].Id },
            };

            List<Turn> turns = new List<Turn>
            {
                new Turn { Id = new Guid("6ba0a3b1-932b-41b3-bc2b-82d720687b59"), CurrentAmountOfThrows = 3, PointsScored = 0, PlayerId = players[0].Id },
                new Turn { Id = new Guid("3226b169-0211-4235-9afd-869b8b79c05e"), CurrentAmountOfThrows = 0, PointsScored = 0, PlayerId = players[1].Id },
            };

            List<ScoreBoardEntry> scoreBoardEntries = new List<ScoreBoardEntry>
            {
                new ScoreBoardEntry{ Id = Guid.NewGuid(), GameId = games[5].Id, PlayerId = players[0].Id, Target = 16, Status = TargetStatus.Closed, TurnId = new Guid("6ba0a3b1-932b-41b3-bc2b-82d720687b59"), DateAndTime = DateTime.Now.AddDays(2) },
                new ScoreBoardEntry{ Id = Guid.NewGuid(), GameId = games[5].Id, PlayerId = players[0].Id, Target = 15, Status = TargetStatus.OnePoint, TurnId = new Guid("6ba0a3b1-932b-41b3-bc2b-82d720687b59"), DateAndTime = DateTime.Now },
                new ScoreBoardEntry{ Id = Guid.NewGuid(), GameId = games[5].Id, PlayerId = players[0].Id, Target = 17, Status = TargetStatus.TwoPoint, TurnId = new Guid("6ba0a3b1-932b-41b3-bc2b-82d720687b59"), DateAndTime = DateTime.Now.AddDays(1) }
            };

            modelBuilder.Entity<Tournament>().HasData(tournaments);
            modelBuilder.Entity<Player>().HasData(players);
            modelBuilder.Entity<Game>().HasData(games);
            modelBuilder.Entity<PlayerGames>().HasData(playerGames);
            modelBuilder.Entity<Turn>().HasData(turns);
            modelBuilder.Entity<ScoreBoardEntry>().HasData(scoreBoardEntries);
        }
    }
}
