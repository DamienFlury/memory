using System.Collections.Generic;
using System.Linq;
using Memory.Models;
using Microsoft.AspNetCore.SignalR;

namespace Memory.Services
{
    public class GameService
    {
        public Player WaitingPlayer { get; private set; }

        public IEnumerable<Game> Games { get; private set; } = new List<Game>();
        
        public Game AddPlayer(string id)
        {
            var newPlayer = new Player(id);
            if(WaitingPlayer is null)
            {
                WaitingPlayer = newPlayer;
                return null;
            }
            var game = new Game(WaitingPlayer, newPlayer);
            Games = Games.Concat(new []{ game });
            WaitingPlayer = null;
            return game;
        }

        public void DisconnectPlayer(string id)
        {
            if (WaitingPlayer?.Id == id)
            {
                WaitingPlayer = null;
            }

            Games = Games.Where(game => game.Player1.Id != id && game.Player2.Id != id);
        }
    }
}