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
                new Game{ Id = Guid.NewGuid(),  IsActive = true, TournamentId = new Guid("243407c9-d7e6-4192-a465-71076a592bf9") }
            };

            List<PlayerGames> playerGames = new List<PlayerGames>
            {
                new PlayerGames{ GameId = games[5].Id, PlayerId = players[0].Id },
                new PlayerGames{ GameId = games[5].Id, PlayerId = players[1].Id },
            };

            List<ScoreBoardEntry> scoreBoardEntries = new List<ScoreBoardEntry>
            {
                new ScoreBoardEntry{ Id = Guid.NewGuid(), GameId = games[5].Id, PlayerId = players[0].Id, Target = 16, Status = TargetStatus.Closed },
                new ScoreBoardEntry{ Id = Guid.NewGuid(), GameId = games[5].Id, PlayerId = players[0].Id, Target = 15, Status = TargetStatus.OnePoint },
                new ScoreBoardEntry{ Id = Guid.NewGuid(), GameId = games[5].Id, PlayerId = players[1].Id, Target = 17, Status = TargetStatus.TwoPoint }
            };

            modelBuilder.Entity<Tournament>().HasData(tournaments);
            modelBuilder.Entity<Player>().HasData(players);
            modelBuilder.Entity<Game>().HasData(games);
            modelBuilder.Entity<PlayerGames>().HasData(playerGames);
            modelBuilder.Entity<ScoreBoardEntry>().HasData(scoreBoardEntries);
        }
    }
}
