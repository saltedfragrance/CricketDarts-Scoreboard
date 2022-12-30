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
                    PersonalStatistics = new PersonalStatisticsResponseDto
                    {
                        Id = p.PersonalStatistics.Id,
                        DoublesThrown = p.PersonalStatistics.DoublesThrown,
                        GamesLost = p.PersonalStatistics.GamesLost,
                        GamesWon = p.PersonalStatistics.GamesWon,
                        TriplesThrown = p.PersonalStatistics.TriplesThrown,
                    },
                    HasTurn= p.HasTurn,
                }),
                ScoreBoardEntries = g.ScoreBoard.Select(x => new ScoreBoardEntryResponseDto
                {
                    Id = x.Id,
                    GameId = x.GameId,
                    PlayerId = x.PlayerId,
                    Status = (int)x.Status,
                    Target = x.Target
                }),
                Scores = g.Scores.Select(x => new ScoreResponseDto
                {
                    Id = x.Id,
                    TotalScore = x.TotalScore,
                    PlayerId = x.PlayerId,
                    GameId = x.GameId
                })
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
                ScoreBoard = gameRequestDto.ScoreBoardEntries.Select(s => new ScoreBoardEntry
                {
                    GameId = gameRequestDto.Id,
                    PlayerId = s.PlayerId,
                    Status = (TargetStatus)s.Status,
                    Target = s.Target,
                }).ToList(),
                Scores = gameRequestDto.Scores.Select(s => new Score
                {

                }).ToList(),
                WinnerId = gameRequestDto.WinnerId,

            };
            await _gameRepository.UpdateAsync(game);
        }
    }
}
