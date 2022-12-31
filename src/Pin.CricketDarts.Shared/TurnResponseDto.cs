using Pin.CricketDarts.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.CricketDarts.Shared
{
    public class TurnResponseDto : BaseDto
    {
        public Guid PlayerId { get; set; }
        public int CurrentAmountOfThrows { get; set; }
        public int CurrentTotalScore { get; set; }
        public ICollection<ScoreBoardEntryResponseDto> ScoreBoardEntries { get; set; }
    }
}
