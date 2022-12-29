using Pin.CricketDarts.Server.Models;

namespace Pin.CricketDarts.Server.Services.Interfaces
{
    public interface IPlayerService
    {
        Task<List<Player>> GetPlayers();
        Task CreatePlayer(Player player);
    }
}
