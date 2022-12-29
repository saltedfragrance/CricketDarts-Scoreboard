using Pin.CricketDarts.Server.Models.Base;

namespace Pin.CricketDarts.Server.Models
{
    public class Score : BaseModel
    {
        public Guid GameId { get; set; }
        public Guid PlayerId { get; set; }
        public Player Player { get; set; }
        public int TotalScore { get; set; }
    }
}
