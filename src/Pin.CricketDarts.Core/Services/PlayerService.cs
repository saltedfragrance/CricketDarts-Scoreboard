﻿using Pin.CricketDarts.Core.Entities;
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
                TournamentId = playerRequestDto.TournamentId,
                HasTurn = playerRequestDto.HasTurn
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
                HasTurn = r.HasTurn,
                Triples = r.Triples,
                Doubles = r.Doubles,
                CurrentTotalScore = r.TotalPointsScored,
                TournamentId = r.TournamentId,
            }).ToList();

            return dtos;
        }

        public Task<PlayerResponseDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(PlayerRequestDto playerRequestDto)
        {
            var player = new Player
            {
                Id = playerRequestDto.Id,
                Name = playerRequestDto.Name,
                HasTurn = playerRequestDto.HasTurn,
                Triples = playerRequestDto.Triples,
                Doubles = playerRequestDto.Doubles,
                TotalPointsScored = playerRequestDto.CurrentTotalScore,
                TournamentId = playerRequestDto.TournamentId
            };

            await _playerRepository.UpdateAsync(player);
        }
    }
}
