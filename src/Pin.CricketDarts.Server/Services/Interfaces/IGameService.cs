using Pin.CricketDarts.Server.Models;

namespace Pin.CricketDarts.Server.Services.Interfaces
{
    public interface IGameService
    {
        Task<List<Game>> GetGames();
        Task CreateGame(Game game);
    }
}
