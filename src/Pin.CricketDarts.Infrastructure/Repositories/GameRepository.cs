using Microsoft.EntityFrameworkCore;
using Pin.CricketDarts.Core.Entities;
using Pin.CricketDarts.Core.Interfaces.Repositories;
using Pin.CricketDarts.Infrastructure.Data;
using Pin.CricketDarts.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.CricketDarts.Infrastructure.Repositories
{
    public class GameRepository : EfRepository<Game>, IGameRepository
    {
        public GameRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<IEnumerable<Game>> GetAllAsync()
        {
            return await _dbContext.Set<Game>().Include(x => x.PlayerGames).Include(g => g.ScoreBoard).ToListAsync();
        }
    }
}
