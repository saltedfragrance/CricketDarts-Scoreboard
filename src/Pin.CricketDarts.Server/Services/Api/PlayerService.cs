using Pin.CricketDarts.Server.Models;
using Pin.CricketDarts.Server.Services.Interfaces;
using Pin.CricketDarts.Shared;

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
                PersonalStatistics = new PersonalStatisticsRequestDto
                {
                    Id = Guid.NewGuid(),
                    DoublesThrown = 0,
                    GamesLost = 0,
                    GamesWon = 0,
                    TriplesThrown = 0,
                }
            };

            return _httpClient.PostAsJsonAsync<PlayerRequestDto>(baseUrl, dto);
        }

        public async Task<List<Player>> GetPlayers()
        {
            var players = await _httpClient.GetFromJsonAsync<Player[]>($"{baseUrl}");

            return players.Select(p => new Player
            {
                Name = p.Name,
                Id = p.Id
            }).ToList();
        }
    }
}
