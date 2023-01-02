using Pin.CricketDarts.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.CricketDarts.Shared
{
    public class ScoreBoardEntryRequestDto : BaseDto
    {
        public Guid GameId { get; set; }
        public Guid PlayerId { get; set; }
        public Guid? CurrentTurnId { get; set; }
        public int Target { get; set; }
        public int Status { get; set; }
        public int Score { get; set; }
        public DateTime DateAndTime { get; set; }
    }
}
