using Pin.CricketDarts.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Pin.CricketDarts.Shared
{
    public class GameResponseDto : BaseDto
    {
        public bool IsActive { get; set; } = false;
        public IEnumerable<PlayerResponseDto> Players { get; set; }
        public Guid WinnerId { get; set; }
        public IEnumerable<ScoreResponseDto> Scores { get; set; }
        public IEnumerable<ScoreBoardEntryResponseDto> ScoreBoardEntries { get; set; }
    }
}
