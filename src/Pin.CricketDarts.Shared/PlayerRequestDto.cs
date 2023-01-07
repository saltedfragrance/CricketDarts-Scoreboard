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
        public bool HasTurn { get; set; }
        public int CurrentAmountOfThrows { get; set; }
        public int CurrentTotalScore { get; set; }
        public int Doubles { get; set; }
        public int Triples { get; set; }
        public Guid TournamentId { get; set; }
    }
}
