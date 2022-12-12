using Microsoft.EntityFrameworkCore;
using Pin.CricketDarts.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.CricketDarts.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Player> Playeers { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<PersonalStatistics> PlayerStatistics { get; set; }
        public DbSet<Score> Score { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
             base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
