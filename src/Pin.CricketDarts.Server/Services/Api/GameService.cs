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
                IsActive = game.IsActive
            };
            return _httpClient.PostAsJsonAsync<GameRequestDto>(baseUrl, dto);
        }

        public Task<List<Game>> GetGames()
        {
            throw new NotImplementedException();
        }
    }
}
