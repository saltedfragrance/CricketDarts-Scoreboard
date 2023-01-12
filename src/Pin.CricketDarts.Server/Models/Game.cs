using Pin.CricketDarts.Server.Models.Base;

namespace Pin.CricketDarts.Server.Models
{
    public class Game : BaseModel
    {
        public bool IsActive { get; set; } = false;
        public Guid? CurrentTurnId { get; set; }
        public IEnumerable<Player> Players { get; set; }
        public Guid? WinnerId { get; set; }
        public List<ScoreBoardEntry> ScoreBoardEntries { get; set; }
        public Guid TournamentId { get; set; }
        public int ScorePlayerOne { get; set; }
        public int ScorePlayerTwo { get; set; }
    }
}
