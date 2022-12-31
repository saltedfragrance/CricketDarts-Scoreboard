using Pin.CricketDarts.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.CricketDarts.Shared
{
    public class TurnRequestDto : BaseDto
    {
        public Guid PlayerId { get; set; }
        public int CurrentAmountOfThrows { get; set; }
        public int CurrentTotalScore { get; set; }
    }
}
