using Pin.CricketDarts.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.CricketDarts.Core.Entities
{
    public class Turn : BaseEntity
    {
        public Guid PlayerId { get; set; }
        public int CurrentAmountOfThrows { get; set; }
        public int PointsScored { get; set; }
        public ICollection<ScoreBoardEntry> ScoreBoardEntries { get; set; }
    }
}
