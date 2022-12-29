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

        public async Task AddAsync(PlayerRequestDto playerRequestDto)
        {
            var player = new Player
            {
                Id = playerRequestDto.Id,
                Name = playerRequestDto.Name,
                PersonalStatistics = new PersonalStatistics
                {
                    Id = playerRequestDto.PersonalStatistics.Id,
                    DoublesThrown = playerRequestDto.PersonalStatistics.DoublesThrown,
                    GamesLost = playerRequestDto.PersonalStatistics.GamesLost,
                    GamesWon = playerRequestDto.PersonalStatistics.GamesWon,
                    TriplesThrown = playerRequestDto.PersonalStatistics.TriplesThrown
                }
            };

            await _playerRepository.AddAsync(player);
        }

        public async Task<IEnumerable<PlayerResponseDto>> GetAllAsync()
        {
            var result = await _playerRepository.GetAllAsync();
            var dtos = result.Select(r => new PlayerResponseDto
            {
                Id = r.Id,
                Name = r.Name,
                PersonalStatistics = new PersonalStatisticsResponseDto
                {
                    Id = r.PersonalStatistics.Id,
                    DoublesThrown = r.PersonalStatistics.DoublesThrown,
                    GamesLost = r.PersonalStatistics.GamesLost,
                    GamesWon = r.PersonalStatistics.GamesWon,
                    TriplesThrown = r.PersonalStatistics.TriplesThrown
                }
            }).ToList();

            return dtos;
        }

        public Task<PlayerResponseDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PlayerResponseDto> UpdateAsync(PlayerRequestDto playerRequestDto)
        {
            throw new NotImplementedException();
        }
    }
}
