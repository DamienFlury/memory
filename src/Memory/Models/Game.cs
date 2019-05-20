using System.Collections.Generic;

namespace Memory.Models
{
    public class Game
    {
        public Game(Player player1, Player player2)
            => (Player1, Player2) = (player1, player2);
        
        public Player Player1 { get; }
        public Player Player2 { get; }

        public IEnumerable<Card> Cards { get; } = new List<Card>()
        {
            new Card(1, 1, ""),
            new Card(2, 1, ""),
            new Card(3, 2, ""),
            new Card(4, 2, ""),
            new Card(5, 3, ""),
            new Card(6, 3, ""),
            new Card(7, 4, ""),
            new Card(8, 4, ""),
            new Card(9, 5, ""),
            new Card(10, 5, ""),
        };
    }
}