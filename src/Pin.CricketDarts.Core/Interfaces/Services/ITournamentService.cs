using Pin.CricketDarts.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.CricketDarts.Core.Interfaces.Services
{
    public interface ITournamentService
    {
        Task<IEnumerable<TournamentResponseDto>> GetAllAsync();
        Task AddAsync(TournamentRequestDto gameRequestDto);
        Task UpdateAsync(TournamentRequestDto gameRequestDto);
    }
}
