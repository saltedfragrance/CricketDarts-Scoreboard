using Pin.CricketDarts.Server.Models;
using Pin.CricketDarts.Server.Services.Interfaces;
using Pin.CricketDarts.Shared;
using System.Net.Http.Json;

namespace Pin.CricketDarts.Server.Services.Api
{
    public class TurnService : ITurnService
    {
        private string baseUrl = "https://localhost:7117/api/Turns";
        private readonly HttpClient _httpClient;

        public TurnService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Turn>> GetTurns()
        {
            var turns = await _httpClient.GetFromJsonAsync<TurnResponseDto[]>($"{baseUrl}");

            return turns.Select(t => new Turn
            {
                Id = t.Id,
                CurrentAmountOfThrows = t.CurrentAmountOfThrows,
                CurrentTotalScore = t.CurrentTotalScore,
                PlayerId = t.PlayerId,
                SelectionMode = t.SelectionMode
            }).ToList();
        }

        public Task CreateTurn(Turn turn)
        {
            var dto = new TurnRequestDto
            {
                Id = turn.Id,
                PlayerId = turn.PlayerId,
                CurrentAmountOfThrows = turn.CurrentAmountOfThrows,
                CurrentTotalScore = turn.CurrentTotalScore,
                SelectionMode = turn.SelectionMode
            };

            return _httpClient.PostAsJsonAsync<TurnRequestDto>(baseUrl, dto);
        }

        public async Task UpdateTurn(Turn turn)
        {
            var dto = new TurnRequestDto
            {
                Id = turn.Id,
                CurrentTotalScore = turn.CurrentTotalScore,
                PlayerId = turn.PlayerId,
                CurrentAmountOfThrows = turn.CurrentAmountOfThrows,
                SelectionMode = turn.SelectionMode
            };

            await _httpClient.PutAsJsonAsync<TurnRequestDto>($"{baseUrl}", dto);
        }
    }
}
