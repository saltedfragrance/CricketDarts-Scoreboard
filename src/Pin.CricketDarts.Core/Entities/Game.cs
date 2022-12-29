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
        public bool IsActive { get; set; } = false;
        public ICollection<PlayerGames> PlayerGames { get; set; }
        public Guid WinnerId { get; set; }
        public ICollection<Score> Scores { get; set; }
    }
}
