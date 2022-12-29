using Pin.CricketDarts.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.CricketDarts.Core.Interfaces.Services
{
    public interface IPlayerService
    {
        Task<IEnumerable<PlayerResponseDto>> GetAllAsync();
        Task<PlayerResponseDto> GetByIdAsync(Guid id);
        Task AddAsync(PlayerRequestDto playerRequestDto);
        Task<PlayerResponseDto> UpdateAsync(PlayerRequestDto playerRequestDto);
    }
}
