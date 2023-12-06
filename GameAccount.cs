using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class GameAccount
    {
        public string UserName { get; private set; }
        public int CurrentRating { get; private set; }
        public int GamesCount { get; private set; }
        private List<GameResult> gameHistory;
        private ChangedRating_Type changeRating;

        public GameAccount(string username, int UserRating, ChangedRating_Type type)
        {
            UserName = username;
            if (UserRating < 1)
            {
                throw new ArgumentException("The rating cannot be less than 1");
            }
            CurrentRating = UserRating;
            GamesCount = 0;
            gameHistory = new List<GameResult>();
            changeRating = type;
        }

        public void WinGame(string opponentName, Game game)
        {
            int GameRating = game.CountRating(true);
            int changed_rating = changeRating.ChangedRating(true);
            if (game.GetType().Name == "TrainingGame")
            {
                CurrentRating += GameRating;
            }
            else
            {
                CurrentRating += GameRating + changed_rating;
            }
            GamesCount++;
            gameHistory.Add(new GameResult(opponentName, true, GameRating, CurrentRating));
        }

        public void LoseGame(string opponentName, Game game)
        {
            int GameRating = game.CountRating(false);
            int changed_rating = changeRating.ChangedRating(false);
            if (CurrentRating - GameRating - changed_rating < 1)
            {
                CurrentRating = 1;
            }
            else if (game.GetType().Name == "TrainingGame")
            {
                CurrentRating += GameRating;
            }
            else
            {
                CurrentRating += GameRating + changed_rating;
            }
            GamesCount++;
            gameHistory.Add(new GameResult(opponentName, false, GameRating, CurrentRating));
        }

        public void GetStats()
        {
            Console.WriteLine($"Stats for {UserName} (Type of user: {changeRating.GetType().Name}):");
            for (int i = 0; i < gameHistory.Count; i++)
            {
                string result = gameHistory[i].WinOrLose ? "Win" : "Lose";
                Console.WriteLine($"Game {i + 1}: Result - {result} | against - {gameHistory[i].OpponentName} | game rating {gameHistory[i].GameRating} | user rating {gameHistory[i].UserRating}");
            }
        }
    }
}
