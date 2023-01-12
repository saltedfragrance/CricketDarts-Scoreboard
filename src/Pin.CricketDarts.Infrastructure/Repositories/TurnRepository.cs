using Pin.CricketDarts.Core.Entities;
using Pin.CricketDarts.Core.Interfaces.Repositories;
using Pin.CricketDarts.Core.Interfaces.Repositories.Base;
using Pin.CricketDarts.Infrastructure.Data;
using Pin.CricketDarts.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.CricketDarts.Infrastructure.Repositories
{
    public class TurnRepository : EfRepository<Turn>, ITurnRepository
    {
        public TurnRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
