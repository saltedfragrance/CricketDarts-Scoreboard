using Pin.CricketDarts.Server.Models;

namespace Pin.CricketDarts.Server.Services.Interfaces
{
    public interface ITurnService
    {
        Task<List<Turn>> GetTurns();
        Task CreateTurn(Turn turn);
        Task UpdateTurn(Turn turn);
    }
}
