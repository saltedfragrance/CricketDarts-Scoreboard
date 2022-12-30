using Pin.CricketDarts.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.CricketDarts.Core.Interfaces.Services
{
    public interface IGameService
    {
        Task<IEnumerable<GameResponseDto>> GetAllAsync();
        Task<GameResponseDto> GetByIdAsync(Guid id);
        Task AddAsync(GameRequestDto gameRequestDto);
        Task UpdateAsync(GameRequestDto gameRequestDto);
    }
}
