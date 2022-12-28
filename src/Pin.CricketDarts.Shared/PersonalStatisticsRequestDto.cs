using Pin.CricketDarts.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.CricketDarts.Shared
{
    public class PersonalStatisticsRequestDto : BaseDto
    {
        public int GamesWon { get; set; }
        public int GamesLost { get; set; }
        public int TriplesThrown { get; set; }
        public int DoublesThrown { get; set; }
    }
}
