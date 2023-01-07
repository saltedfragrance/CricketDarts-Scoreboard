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
    public class TournamentService : ITournamentService
    {
        private readonly ITournamentRepository _tournamentRepository;

        public TournamentService(ITournamentRepository tournamentRepository)
        {
            _tournamentRepository = tournamentRepository;
        }

        public async Task AddAsync(TournamentRequestDto tournamentRequestDto)
        {
            var toAdd = new Tournament
            {
                Id = gameRequestDto.Id,
                IsOngoing = gameRequestDto.IsOngoing,
            };

            await _tournamentRepository.AddAsync(toAdd);
        }

        public async Task<IEnumerable<TournamentResponseDto>> GetAllAsync()
        {
            var tournaments = await _tournamentRepository.GetAllAsync();

            return tournaments.Select(t => new TournamentResponseDto
            {
                Id = t.Id,
                IsOngoing = t.IsOngoing,
            }).ToList();
        }

        public async Task UpdateAsync(TournamentRequestDto tournamentRequestDto)
        {
            var toUpdate = new Tournament
            {
                Id = tournamentRequestDto.Id,
                IsOngoing = tournamentRequestDto.IsOngoing
            };

            await _tournamentRepository.UpdateAsync(toUpdate);
        }
    }
}
