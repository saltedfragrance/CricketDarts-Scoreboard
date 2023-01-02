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
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IPlayerRepository _playerRepository;

        public GameService(IPlayerRepository playerRepository, IGameRepository gameRepository)
        {
            _playerRepository = playerRepository;
            _gameRepository = gameRepository;
        }

        public async Task AddAsync(GameRequestDto gameRequestDto)
        {
            var game = new Game
            {
                Id = gameRequestDto.Id,
                IsActive = gameRequestDto.IsActive
            };
            await _gameRepository.AddAsync(game);
        }

        public async Task<IEnumerable<GameResponseDto>> GetAllAsync()
        {
            var games = await _gameRepository.GetAllAsync();
            var players = await _playerRepository.GetAllAsync();

            return games.Select(g => new GameResponseDto
            {
                Id = g.Id,
                IsActive = g.IsActive,
                Players = players.Where(p => g.PlayerGames.Any(pg => pg.PlayerId == p.Id)).Select(p => new PlayerResponseDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    HasTurn = p.HasTurn,
                    Doubles = p.Doubles,
                    Triples = p.Triples,
                    CurrentTotalScore = p.TotalPointsScored
                }),
                ScoreBoardEntries = g.ScoreBoard.Select(x => new ScoreBoardEntryResponseDto
                {
                    Id = x.Id,
                    GameId = x.GameId,
                    PlayerId = x.PlayerId,
                    Status = (int)x.Status,
                    Target = x.Target,
                    Score = x.Score,
                    CurrentTurnId = x.TurnId,
                    DateAndTime = x.DateAndTime
                }),
                TournamentId = g.TournamentId,
                CurrentTurnId = g.CurrentTurnId
            }).ToList();
        }

        public Task<GameResponseDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(GameRequestDto gameRequestDto)
        {
            var game = new Game
            {
                Id = gameRequestDto.Id,
                IsActive = gameRequestDto.IsActive,
                WinnerId = gameRequestDto.WinnerId,
                CurrentTurnId = gameRequestDto.CurrentTurnId,
                TournamentId = gameRequestDto.TournamentId,
            };
            await _gameRepository.UpdateAsync(game);
        }
    }
}
