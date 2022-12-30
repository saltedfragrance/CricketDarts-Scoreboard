using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.CricketDarts.Shared
{
    public class ScoreRequestDto
    {
        public Guid GameId { get; set; }
        public Guid PlayerId { get; set; }
        public PlayerRequestDto Player { get; set; }
        public int TotalScore { get; set; }
        public IEnumerable<ScoreBoardEntryRequestDto> ScoreBoardEntries { get; set; }
    }
}
