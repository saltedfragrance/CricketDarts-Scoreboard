using Pin.CricketDarts.Server.Models.Base;

namespace Pin.CricketDarts.Server.Models
{
    public class Turn : BaseModel
    {
        public Guid PlayerId { get; set; }
        public int CurrentAmountOfThrows { get; set; }
        public int CurrentTotalScore { get; set; }
        public ICollection<ScoreBoardEntry> ScoreBoardEntries { get; set; }
        public bool SelectionMode { get; set; }
    }
}
