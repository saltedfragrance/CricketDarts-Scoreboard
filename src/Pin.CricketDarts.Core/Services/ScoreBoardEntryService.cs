using Pin.CricketDarts.Core.Entities;
using Pin.CricketDarts.Core.Enums;
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
    public class ScoreBoardEntryService : IScoreBoardEntryService
    {
        private readonly IScoreBoardEntryRepository _scoreBoardEntryRepository;

        public ScoreBoardEntryService(IScoreBoardEntryRepository scoreBoardEntryRepository)
        {
            _scoreBoardEntryRepository = scoreBoardEntryRepository;
        }

        public async Task AddAsync(ScoreBoardEntryRequestDto scoreBoardEntryRequestDto)
        {
            var scoreBoardEntry = new ScoreBoardEntry
            {
                Id = Guid.NewGuid(),
                GameId = scoreBoardEntryRequestDto.GameId,
                PlayerId = scoreBoardEntryRequestDto.PlayerId,
                Status = (TargetStatus)scoreBoardEntryRequestDto.Status,
                Target = scoreBoardEntryRequestDto.Target,
                TurnId = scoreBoardEntryRequestDto.CurrentTurnId,
                Score = scoreBoardEntryRequestDto.Score,
                DateAndTime = scoreBoardEntryRequestDto.DateAndTime
            };
            await _scoreBoardEntryRepository.AddAsync(scoreBoardEntry);
        }

        public async Task<IEnumerable<ScoreBoardEntryResponseDto>> GetAllAsync()
        {
            var result = await _scoreBoardEntryRepository.GetAllAsync();

            var dtos = result.Select(x => new ScoreBoardEntryResponseDto
            {
                GameId = x.GameId,
                Id = x.Id,
                PlayerId = x.PlayerId,
                Status = (int)x.Status,
                Target = x.Target,
                Score = x.Score,
                CurrentTurnId = x.TurnId,
                DateAndTime = x.DateAndTime
            }).ToList();

            return dtos;
        }

        public Task<ScoreBoardEntryResponseDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(ScoreBoardEntryRequestDto scoreBoardEntryRequestDto)
        {
            var scoreBoardEntry = new ScoreBoardEntry
            {
                Id = scoreBoardEntryRequestDto.Id,
                GameId = scoreBoardEntryRequestDto.GameId,
                PlayerId = scoreBoardEntryRequestDto.PlayerId,
                Status = (TargetStatus)scoreBoardEntryRequestDto.Status,
                Target = scoreBoardEntryRequestDto.Target,
                TurnId = scoreBoardEntryRequestDto.CurrentTurnId,
                Score = scoreBoardEntryRequestDto.Score,
                DateAndTime = scoreBoardEntryRequestDto.DateAndTime
            };

            await _scoreBoardEntryRepository.UpdateAsync(scoreBoardEntry);
        }
    }
}
