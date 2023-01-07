using Pin.CricketDarts.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.CricketDarts.Shared
{
    public class TournamentRequestDto : BaseDto
    {
        public bool IsOngoing { get; set; }
    }
}
