using Pin.CricketDarts.Core.Entities.Base;
using Pin.CricketDarts.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.CricketDarts.Core.Entities
{
    public class ScoreBoardEntry : BaseEntity
    {
        public Guid? TurnId { get; set; }
        public Turn? Turn { get; set; }
        public Guid GameId { get; set; }
        public Game Game { get; set; }
        public Guid PlayerId { get; set; }
        public Player Player { get; set; }
        public int Target { get; set; }
        public TargetStatus Status { get; set; }
        public int Score { get; set; }
    }
}
