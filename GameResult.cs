using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class GameResult
    {
        public string OpponentName { get; }
        public bool WinOrLose { get; }
        public int GameRating { get; }
        public int UserRating { get; }

        public GameResult(string opponentName, bool winORlose, int gameRating, int userRating)
        {
            OpponentName = opponentName;
            WinOrLose = winORlose;
            GameRating = gameRating;
            UserRating = userRating;
        }
    }
}
