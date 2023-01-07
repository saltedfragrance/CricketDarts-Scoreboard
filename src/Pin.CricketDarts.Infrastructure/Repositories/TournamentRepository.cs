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
    public class TournamentRepository : EfRepository<Tournament>, ITournamentRepository
    {
        public TournamentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<IEnumerable<Tournament>> GetAllAsync()
        {
            return await _dbContext.Set<Tournament>().Include(g => g.Participants).Include(g => g.Games).ToListAsync();
        }
    }
}
