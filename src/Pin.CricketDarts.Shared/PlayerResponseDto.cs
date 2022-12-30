using Pin.CricketDarts.Shared.Base;

namespace Pin.CricketDarts.Shared
{
    public class PlayerResponseDto : BaseDto
    {
        public string Name { get; set; }
        public PersonalStatisticsResponseDto PersonalStatistics { get; set; }
        public bool HasTurn { get; set; }
    }
}