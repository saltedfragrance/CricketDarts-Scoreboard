using Pin.CricketDarts.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.CricketDarts.Core.Entities
{
    public class Game : BaseEntity
    {
        public Guid TournamentId { get; set; }
        public Tournament Tournament { get; set; }
        public Guid? CurrentTurnId { get; set; }
        public bool IsActive { get; set; } = false;
        public Guid? WinnerId { get; set; }
        public ICollection<ScoreBoardEntry> ScoreBoard { get; set; }
        public ICollection<PlayerGame> PlayerGames { get; set; }
    }
}
