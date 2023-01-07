using Pin.CricketDarts.Server.Models;
using Pin.CricketDarts.Server.Services.Interfaces;
using Pin.CricketDarts.Shared;
using System.Net.Http.Json;

namespace Pin.CricketDarts.Server.Services.Api
{
    public class TournamentService : ITournamentService
    {
        private string baseUrl = "https://localhost:7117/api/Tournaments";
        private readonly HttpClient _httpClient;
        public TournamentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateTournament(Tournament tournament)
        {
            var dto = new TournamentRequestDto
            {
                Id = tournament.Id,
                IsOngoing = tournament.IsOngoing
            };

            await _httpClient.PostAsJsonAsync<TournamentRequestDto>(baseUrl, dto);
        }

        public async Task<List<Tournament>> GetTournaments()
        {
            var tournaments = await _httpClient.GetFromJsonAsync<TournamentResponseDto[]>($"{baseUrl}");

            return tournaments.Select(t => new Tournament
            {
                Id = t.Id,
                IsOngoing = t.IsOngoing,
                Games = t.Games.Select(g => new Game
                {
                    Id = g.Id,
                    WinnerId = g.WinnerId,
                    TournamentId = g.TournamentId,
                    CurrentTurnId = g.CurrentTurnId,
                    IsActive = g.IsActive
                }).ToList(),
                Participants = t.Participants.Select(p => new Player
                {
                    Id = p.Id,
                    Triples = p.Triples,
                    Name = p.Name,
                    HasTurn = p.HasTurn,
                    Doubles = p.Doubles,
                    CurrentAmountOfThrows = p.CurrentAmountOfThrows,
                    CurrentTotalScore = p.CurrentTotalScore,
                    CurrentTournamentId = p.TournamentId
                }).ToList()
            }).ToList();
        }

        public async Task UpdateTournament(Tournament tournament)
        {
            var dto = new TournamentRequestDto
            {
                Id = tournament.Id,
                IsOngoing = tournament.IsOngoing,
            };
            await _httpClient.PutAsJsonAsync<TournamentRequestDto>($"{baseUrl}", dto);
        }
    }
}
