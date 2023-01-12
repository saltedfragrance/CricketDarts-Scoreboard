namespace Pin.CricketDarts.Server.Models.Statistics
{
    public class DartsPlayer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int CurrentScore { get; set; }
        public int TotalDoubles { get; set; }
        public int TotalTriples { get; set; }
        public int AmountWonGames { get; set; }
    }
}
