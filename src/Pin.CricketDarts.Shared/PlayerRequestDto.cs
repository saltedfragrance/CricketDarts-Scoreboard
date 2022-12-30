using Pin.CricketDarts.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.CricketDarts.Shared
{
    public class PlayerRequestDto : BaseDto
    {
        public string Name { get; set; }
        public PersonalStatisticsRequestDto PersonalStatistics { get; set; }
        public bool HasTurn { get; set; }
    }
}
