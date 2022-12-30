using Microsoft.EntityFrameworkCore;
using Pin.CricketDarts.Core.Entities;
using Pin.CricketDarts.Infrastructure.Data.Seeding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pin.CricketDarts.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PersonalStatistics> PlayerStatistics { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<PlayerGames> PlayerGames { get; set; }
        public DbSet<Score> Score { get; set; }
        public DbSet<ScoreBoardEntry> ScoreBoardEntries { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
             base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerGames>()
                .HasKey(pg => new { pg.GameId, pg.PlayerId });

            base.OnModelCreating(modelBuilder);
            Seeder.Seed(modelBuilder);
        }
    }
}
