using Pin.CricketDarts.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.CricketDarts.Shared
{
    public class GameRequestDto : BaseDto
    {
        public bool IsActive { get; set; } = false;
        public IEnumerable<PlayerRequestDto> Players { get; set; }
        public Guid? WinnerId { get; set; }
        public Guid? CurrentTurnId { get; set; }
        public Guid TournamentId { get; set; }
    }
}