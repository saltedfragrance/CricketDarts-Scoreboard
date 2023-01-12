using Microsoft.EntityFrameworkCore;
using Pin.CricketDarts.Core.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pin.CricketDarts.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<ScoreBoardEntry> ScoreBoardEntries { get; set; }
        public DbSet<PlayerGame> PlayerGame { get; set; }
        public DbSet<Turn> Turns { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
             base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().HasOne(t => t.Tournament).WithMany(x => x.Participants).HasForeignKey(t => t.TournamentId).IsRequired(false);

            modelBuilder.Entity<PlayerGame>()
                .ToTable("PlayerGame")
                .HasKey(pg => new { pg.PlayerId, pg.GameId });

            modelBuilder.Entity<PlayerGame>()
                .HasOne(pg => pg.Player)
                .WithMany(pg => pg.PlayerGames)
                .HasForeignKey(pg => pg.PlayerId);

            modelBuilder.Entity<PlayerGame>()
                .HasOne(pg => pg.Game)
                .WithMany(a => a.PlayerGames)
                .HasForeignKey(pg => pg.GameId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
