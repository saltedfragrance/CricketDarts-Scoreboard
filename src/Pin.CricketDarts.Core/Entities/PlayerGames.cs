using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.CricketDarts.Core.Entities
{
    public class PlayerGames
    {
        public Guid PlayerId { get; set; }
        public Player Player { get; set; }
        public Guid GameId { get; set; }
        public Game Game { get; set; }
    }
}
