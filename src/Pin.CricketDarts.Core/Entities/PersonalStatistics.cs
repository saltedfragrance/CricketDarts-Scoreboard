using Pin.CricketDarts.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.CricketDarts.Core.Entities
{
    public class PersonalStatistics : BaseEntity
    {
        public int GamesWon { get; set; }
        public int GamesLost { get; set; }
        public int TriplesThrown { get; set; }
        public int DoublesThrown { get; set; }
    }
}
