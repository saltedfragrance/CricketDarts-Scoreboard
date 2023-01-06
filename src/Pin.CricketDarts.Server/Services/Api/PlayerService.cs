using Pin.CricketDarts.Server.Models;
using Pin.CricketDarts.Server.Services.Interfaces;
using Pin.CricketDarts.Shared;
using System.Net.Http.Json;

namespace Pin.CricketDarts.Server.Services.Api
{
    public class PlayerService : IPlayerService
    {
        private string baseUrl = "https://localhost:7117/api/Players";
        private readonly HttpClient _httpClient;

        public PlayerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task CreatePlayer(Player player)
        {
            var dto = new PlayerRequestDto
            {
                Name = player.Name,
                Id = Guid.NewGuid(),
                HasTurn = player.HasTurn
            };

            return _httpClient.PostAsJsonAsync<PlayerRequestDto>(baseUrl, dto);
        }

        public async Task<List<Player>> GetPlayers()
        {
            var players = await _httpClient.GetFromJsonAsync<Player[]>($"{baseUrl}");

            return players.Select(p => new Player
            {
                Name = p.Name,
                Id = p.Id,
                HasTurn = p.HasTurn,
                CurrentAmountOfThrows = p.CurrentAmountOfThrows,
                CurrentTotalScore = p.CurrentTotalScore,
                Doubles = p.Doubles,
                Triples = p.Triples,
            }).ToList();
        }
        public async Task UpdatePlayer(Player player)
        {
            var dto = new PlayerRequestDto
            {
                Name = player.Name,
                Triples = player.Triples,
                Doubles = player.Doubles,
                CurrentAmountOfThrows = player.CurrentAmountOfThrows,
                CurrentTotalScore = player.CurrentTotalScore,
                HasTurn = player.HasTurn,
                Id = player.Id,
            };
            await _httpClient.PutAsJsonAsync<PlayerRequestDto>($"{baseUrl}", dto);

        }
    }
}
