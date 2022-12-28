using Pin.CricketDarts.Server.Models;

namespace Pin.CricketDarts.Server.Services.Interfaces
{
    public interface IPlayerService
    {
        Task CreatePlayer(Player player);
    }
}
