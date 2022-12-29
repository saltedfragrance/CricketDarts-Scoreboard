using Pin.CricketDarts.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Pin.CricketDarts.Shared
{
    public class ScoreResponseDto : BaseDto
    {
        public Guid GameId { get; set; }
        public Guid PlayerId { get; set; }
        public PlayerResponseDto Player { get; set; }
        public int TotalScore { get; set; }
    }
}
