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
    public class TurnService : ITurnService
    {
        private readonly ITurnRepository _turnRepository;

        public TurnService(ITurnRepository turnRepository)
        {
            _turnRepository = turnRepository;
        }

        public async Task AddAsync(TurnRequestDto turnRequestDto)
        {
            var turn = new Turn
            {
                CurrentAmountOfThrows = turnRequestDto.CurrentAmountOfThrows,
                PointsScored = turnRequestDto.CurrentTotalScore,
                Id = turnRequestDto.Id,
                PlayerId = turnRequestDto.PlayerId
            };
            await _turnRepository.AddAsync(turn);
        }

        public async Task<IEnumerable<TurnResponseDto>> GetAllAsync()
        {
            var turns = await _turnRepository.GetAllAsync();

            return turns.Select(t => new TurnResponseDto
            {
                Id = t.Id,
                CurrentAmountOfThrows = t.CurrentAmountOfThrows,
                CurrentTotalScore = t.PointsScored,
                PlayerId = t.PlayerId

            });
        }

        public async Task<TurnResponseDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(TurnRequestDto turnRequestDto)
        {
            var turn = new Turn
            {
                Id = turnRequestDto.Id,
                PlayerId = turnRequestDto.PlayerId,
                PointsScored = turnRequestDto.CurrentTotalScore,
                CurrentAmountOfThrows = turnRequestDto.CurrentAmountOfThrows
            };

            await _turnRepository.UpdateAsync(turn);
        }
    }
}
