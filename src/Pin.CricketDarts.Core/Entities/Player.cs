using Pin.CricketDarts.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.CricketDarts.Core.Entities
{
    public class Player : BaseEntity
    {
        public string Name { get; set; }
        public int TotalPointsScored { get; set; }
        public bool HasTurn { get; set; }
        public int Doubles { get; set; }
        public int Triples { get; set; }
        public Guid TournamentId { get; set; }
        public Tournament Tournament { get; set; }
        public ICollection<PlayerGame> PlayerGames { get; set; }
    }
}
