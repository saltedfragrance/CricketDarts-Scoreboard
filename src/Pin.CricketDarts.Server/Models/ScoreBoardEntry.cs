using Pin.CricketDarts.Server.Models.Base;

namespace Pin.CricketDarts.Server.Models
{
    public class ScoreBoardEntry : BaseModel
    {
        public Guid GameId { get; set; }
        public Guid? TurnId { get; set; }
        public Guid PlayerId { get; set; }
        public int Target { get; set; }
        public int Status { get; set; }
        public int Score { get; set; }
        public DateTime DateAndTime { get; set; }
        public int AmountClicks { get; set; }
    }
}
