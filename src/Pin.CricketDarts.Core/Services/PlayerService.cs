using Pin.CricketDarts.Core.Entities;
using Pin.CricketDarts.Core.Interfaces.Repositories;
using Pin.CricketDarts.Core.Interfaces.Services;
using Pin.CricketDarts.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.CricketDarts.Core.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task AddAsync(PlayerRequestDto albumRequest)
        {
            var player = new Player
            {
                Id = new Guid(),
                Name = albumRequest.Name,
            };

            await _playerRepository.AddAsync(player);
        }

        public async Task<PlayerResponseDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PlayerResponseDto>> ListAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
