using Pin.CricketDarts.Server.Models;

namespace Pin.CricketDarts.Server.Services.Interfaces
{
    public interface ITournamentService
    {
        Task<List<Tournament>> GetTournaments();
        Task CreateTournament(Tournament turn);
        Task UpdateTournament(Tournament turn);
    }
}
