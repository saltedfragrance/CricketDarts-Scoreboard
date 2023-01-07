using Pin.CricketDarts.Shared.Base;

namespace Pin.CricketDarts.Shared
{
    public class PlayerResponseDto : BaseDto
    {
        public string Name { get; set; }
        public bool HasTurn { get; set; }
        public int CurrentAmountOfThrows { get; set; }
        public int CurrentTotalScore { get; set; }
        public int Doubles { get; set; }
        public int Triples { get; set; }
        public Guid TournamentId { get; set; }
    }
}