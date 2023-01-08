using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using Pin.CricketDarts.Server.Models;
using Pin.CricketDarts.Server.Models.Statistics;
using Pin.CricketDarts.Server.Services.Interfaces;

namespace Pin.CricketDarts.Server.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IGameService _gameService;
        private readonly IPlayerService _playerService;
        private readonly IScoreBoardEntryService _scoreBoardEntryService;
        private HubConnection hubConnection;
        private readonly NavigationManager _navMagager;

        public StatisticsService(IGameService gameService, IPlayerService playerService, NavigationManager navManager, IScoreBoardEntryService scoreBoardEntryService)
        {
            _gameService = gameService;
            _playerService = playerService;
            _navMagager = navManager;
            _scoreBoardEntryService = scoreBoardEntryService;
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
                    }).ToList(),
                    IsActive = g.IsActive,
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
        private async Task<int> GetAverageScore(DartsPlayer player)
        {
            var scoreBoardEntries = (await _scoreBoardEntryService.GetScoreBoardEntries()).Where(s => s.PlayerId == player.Id).ToList();

            var gamesCount = scoreBoardEntries.GroupBy(s => s.GameId).Count();
            var totalScore = scoreBoardEntries.Sum(s => s.Score);
            if (totalScore > 0 && gamesCount > 0)
            {
                return totalScore / gamesCount;
            }
            else return 0;
        }

        private async Task<List<DartsPlayer>> SortPlayersByAverageScore(List<DartsPlayer> allPlayers)
        {
            if (allPlayers != null)
            {
                if (allPlayers.Count() >= 2)
                {
                    for (int i = 0; i < allPlayers.Count(); i++)
                    {
                        if (i != 0)
                        {
                            var previousPlayer = allPlayers[i - 1];
                            var currentPlayer = allPlayers[i];
                            var averageScorePreviousPlayer = await GetAverageScore(previousPlayer);
                            var averageScoreCurrentPlayer = await GetAverageScore(currentPlayer);

                            if ((averageScoreCurrentPlayer > averageScorePreviousPlayer) && (currentPlayer.AmountWonGames == previousPlayer.AmountWonGames) && currentPlayer.AmountWonGames != 0 && previousPlayer.AmountWonGames != 0)
                            {
                                allPlayers.Reverse(i, 2);
                            }

                        }
                    }
                }
            }
            return allPlayers;
        }

    }
}
