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
    public class PlayerRepository : EfRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public override async Task<IEnumerable<Player>> GetAllAsync()
        {
            return await _dbContext.Set<Player>().Include(x => x.PersonalStatistics).ToListAsync();
        }
    }
}
