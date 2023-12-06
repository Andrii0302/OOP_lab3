using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{

    // Сутність гри
    public class GameData
    {
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public string OpponentName { get; set; }
        public int Points { get; set; }
        public string Result { get; set; }

        public GameData(int playerId, string opponentName, int points, string result)
        {
            PlayerId = playerId;
            OpponentName = opponentName;
            Points = points;
            Result = result;
        }
    }

}
