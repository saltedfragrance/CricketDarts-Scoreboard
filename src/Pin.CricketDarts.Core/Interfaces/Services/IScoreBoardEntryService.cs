using Pin.CricketDarts.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.CricketDarts.Core.Interfaces.Services
{
    public interface IScoreBoardEntryService
    {
        Task<IEnumerable<ScoreBoardEntryResponseDto>> GetAllAsync();
        Task<ScoreBoardEntryResponseDto> GetByIdAsync(Guid id);
        Task AddAsync(ScoreBoardEntryRequestDto scoreBoardEntryRequestDto);
        Task UpdateAsync(ScoreBoardEntryRequestDto scoreBoardEntryRequestDto);
    }
}
