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
        public bool ActiveGame { get; set; } = false;
        public ICollection<Player> Players { get; set; }
        public Guid WinnerId { get; set; }
        public Player Winner { get; set; }
        public ICollection<Score> Score { get; set; }
    }
}
