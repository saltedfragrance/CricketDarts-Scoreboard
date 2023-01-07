using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using Pin.CricketDarts.Server.Models.Statistics;
using Pin.CricketDarts.Server.Services.Interfaces;

namespace Pin.CricketDarts.Server.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IGameService _gameService;
        private readonly IPlayerService _playerService;
        private HubConnection hubConnection;
        private readonly NavigationManager _navMagager;

        public StatisticsService(IGameService gameService, IPlayerService playerService, NavigationManager navManager)
        {
            _gameService = gameService;
            _playerService = playerService;
            _navMagager = navManager;
        }

        public async Task<OngoingGames> GetCurrentGames()
        {
            var allGames = (await _gameService.GetGames());
            var activeGames = allGames.Where(g => g.IsActive).ToList();
            var players = (await GetAllPlayers());

            OngoingGames ongoingGames = new OngoingGames();
            ongoingGames.CurrentOngoingGames = new();

            activeGames.ForEach(g =>
            {
                var game = new DartsGame
                {
                    Players = g.Players.Select(p => new DartsPlayer
                    {
                        Id = p.Id,
                        Name = p.Name,
                        CurrentScore = p.CurrentTotalScore,
                        TotalDoubles = p.Doubles,
                        TotalTriples = p.Triples
                    }).ToList()
                };

                game.Players.ForEach(p =>
                {
                    var winnerCount = allGames.Where(g => g.WinnerId == p.Id).Count();
                    p.AmountWonGames = winnerCount;
                });

                ongoingGames.CurrentOngoingGames.Add(game);
            });

            return ongoingGames;
        }
        public async Task<List<DartsPlayer>> GetAllPlayers()
        {
            var players = await _playerService.GetPlayers();
            var allGames = (await _gameService.GetGames());

            var allPlayers = players.Select(p => new DartsPlayer
            {
                Id = p.Id,
                Name = p.Name,
                TotalDoubles = p.Doubles,
                TotalTriples = p.Triples,
                CurrentScore = p.CurrentTotalScore
            }).ToList();

            allPlayers.ForEach(p =>
            {
                var winnerCount = allGames.Where(g => g.WinnerId == p.Id).Count();
                p.AmountWonGames = winnerCount;
            });

            return allPlayers.OrderByDescending(p => p.AmountWonGames).ToList();
        }

        public async Task SendStatistics()
        {
            var ongoingGames = await GetCurrentGames();
            var allPlayers = await GetAllPlayers();

            hubConnection = new HubConnectionBuilder().WithUrl(_navMagager.ToAbsoluteUri("/statisticshub")).Build();

            await hubConnection.StartAsync();
            await hubConnection.SendAsync("SendOngoingGames", ongoingGames);
            await hubConnection.SendAsync("SendAllPlayers", allPlayers);
        }
    }
}
