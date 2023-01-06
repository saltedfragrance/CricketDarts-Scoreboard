using Pin.CricketDarts.Server.Models.Statistics;

namespace Pin.CricketDarts.Server.Services.Interfaces
{
    public interface IStatisticsService
    {
        Task<OngoingGames> GetCurrentGames();
        Task<List<DartsPlayer>> GetAllPlayers();
        Task SendStatistics();
    }
}
