using System;
using System.Linq;
using System.Threading.Tasks;
using Memory.Services;
using Microsoft.AspNetCore.SignalR;

namespace Memory.Hubs
{
    public class GameHub : Hub
    {
        public GameService GameService { get; }

        public GameHub(GameService gameService)
            => (GameService) = (gameService);

        public override async Task OnConnectedAsync()
        {
            var game = GameService.AddPlayer(Context.ConnectionId);
            if (!(game is null))
            {
                await Clients.Client(game.Player1.Id).SendAsync("gameFound", game);
                await Clients.Client(game.Player2.Id).SendAsync("gameFound", game);
            }
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var game = GameService.Games.FirstOrDefault(g =>
                g.Player1.Id == Context.ConnectionId || g.Player2.Id == Context.ConnectionId);
            
            if (!(game is null))
            {
                await Clients.Client(game.Player1.Id).SendAsync("opponentDisconnected");
                await Clients.Client(game.Player2.Id).SendAsync("opponentDisconnected");
            }
            
            GameService.DisconnectPlayer(Context.ConnectionId);
        }
    }
}