using Pin.CricketDarts.Server.Models.Base;

namespace Pin.CricketDarts.Server.Models
{
    public class Game : BaseModel
    {
        public bool IsActive { get; set; } = false;
        public IEnumerable<Player> Players { get; set; }
        public Guid WinnerId { get; set; }
        public IEnumerable<Score> Scores { get; set; }
        public List<ScoreBoardEntry> ScoreBoardEntries { get; set; }
    }
}
