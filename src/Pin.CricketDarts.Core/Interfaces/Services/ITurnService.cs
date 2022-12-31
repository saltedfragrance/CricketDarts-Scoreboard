using Pin.CricketDarts.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.CricketDarts.Core.Interfaces.Services
{
    public interface ITurnService
    {
        Task<IEnumerable<TurnResponseDto>> GetAllAsync();
        Task<TurnResponseDto> GetByIdAsync(Guid id);
        Task AddAsync(TurnRequestDto playerRequestDto);
        Task UpdateAsync(TurnRequestDto playerRequestDto);
    }
}
