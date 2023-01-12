using Pin.CricketDarts.Server.Models.Base;

namespace Pin.CricketDarts.Server.Models
{
    public class Tournament : BaseModel
    {
        public bool IsOngoing { get; set; }
        public IEnumerable<Game> Games { get; set; }
        public IEnumerable<Player> Participants { get; set; }
    }
}
