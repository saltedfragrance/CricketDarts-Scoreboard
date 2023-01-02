using Pin.CricketDarts.Server.Models;
using Pin.CricketDarts.Server.Services.Interfaces;
using Pin.CricketDarts.Shared;
using System.Net.Http;

namespace Pin.CricketDarts.Server.Services.Api
{
    public class GameService : IGameService
    {
        private string baseUrl = "https://localhost:7117/api/Games";
        private readonly HttpClient _httpClient;

        public GameService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task CreateGame(Game game)
        {
            var dto = new GameRequestDto
            {
                Id = game.Id,
                IsActive = game.IsActive,
                CurrentTurnId = game.CurrentTurnId
            };
            return _httpClient.PostAsJsonAsync<GameRequestDto>(baseUrl, dto);
        }

        public async Task<List<Game>> GetGames()
        {
            var games = await _httpClient.GetFromJsonAsync<GameResponseDto[]>($"{baseUrl}");

            return games.Select(p => new Game
            {
                Id = p.Id,
                IsActive = p.IsActive,
                Players = p.Players.Select(c => new Player
                {
                    Id = c.Id,
                    Name = c.Name,
                    HasTurn = c.HasTurn,
                    CurrentAmountOfThrows = c.CurrentAmountOfThrows,
                    CurrentTotalScore = c.CurrentTotalScore,
                    Doubles = c.Doubles,
                    Triples = c.Triples,
                }).ToList(),
                ScoreBoardEntries = p.ScoreBoardEntries.Select(s => new ScoreBoardEntry
                {
                    GameId = s.GameId,
                    Id = s.Id,
                    PlayerId = s.PlayerId,
                    Status = s.Status,
                    Target = s.Target,
                    Score = s.Score,
                    TurnId = s.CurrentTurnId,
                    DateAndTime = s.DateAndTime,
                }).ToList(),
                WinnerId = p.WinnerId,
                CurrentTurnId = p.CurrentTurnId,
                TournamentId = p.TournamentId,
            }).ToList();
        }

        public async Task UpdateGame(Game game)
        {
            var dto = new GameRequestDto
            {
                Id = game.Id,
                IsActive = game.IsActive,
                ScoreBoardEntries = game.ScoreBoardEntries.Select(s => new ScoreBoardEntryRequestDto
                {
                    GameId = s.Id,
                    PlayerId = s.PlayerId,
                    Status = s.Status,
                    Target = s.Target,
                    Score = s.Score,
                    DateAndTime = s.DateAndTime,
                    CurrentTurnId = s.TurnId,
                    Id = game.Id
                }).ToList(),
                Players = game.Players.Select(p => new PlayerRequestDto
                {
                    Name = p.Name,
                    CurrentAmountOfThrows = p.CurrentAmountOfThrows,
                    CurrentTotalScore = p.CurrentTotalScore,
                    Doubles = p.Doubles,
                    HasTurn = p.HasTurn
                }).ToList(),
                WinnerId = game.WinnerId,
                CurrentTurnId = game.CurrentTurnId,
                TournamentId = game.TournamentId
            };

            await _httpClient.PutAsJsonAsync<GameRequestDto>($"{baseUrl}", dto);
        }
    }
}
