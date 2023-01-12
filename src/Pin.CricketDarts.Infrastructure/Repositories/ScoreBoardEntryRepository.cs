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
    public class ScoreBoardEntryRepository : EfRepository<ScoreBoardEntry>, IScoreBoardEntryRepository
    {
        public ScoreBoardEntryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
