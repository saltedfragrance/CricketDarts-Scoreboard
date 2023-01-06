using Microsoft.AspNetCore.SignalR;
using Pin.CricketDarts.Server.Models.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Pin.CricketDarts.Infrastructure.Hubs
{
    public class GamesStatisticsHub : Hub
    {
        public async Task SendOngoingGames(OngoingGames gamesModel)
        {
            await Clients.Others.SendAsync("ReceiveOngoingGames", gamesModel);
        }
        public async Task SendAllPlayers(List<DartsPlayer> allPlayers)
        {
            await Clients.Others.SendAsync("ReceiveAllPlayers", allPlayers);
        }
    }
}
