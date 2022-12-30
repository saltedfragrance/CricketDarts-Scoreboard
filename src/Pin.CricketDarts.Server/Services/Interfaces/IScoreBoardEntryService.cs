using Pin.CricketDarts.Server.Models;

namespace Pin.CricketDarts.Server.Services.Interfaces
{
    public interface IScoreBoardEntryService
    {
        Task<List<ScoreBoardEntry>> GetScoreBoardEntries();
        Task CreateScoreBoardEntry(ScoreBoardEntry scoreBoardEntry);
        Task UpdateScoreBoardEntry(ScoreBoardEntry scoreBoardEntry);
    }
}
