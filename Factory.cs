using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class GameFactory
    {
        public static Game CreateStandardGame()
        {
            return new StandardGame();
        }

        public static Game CreateTrainingGame()
        {
            return new TrainingGame();
        }

        public static Game CreateSinglePlayerGame()
        {
            return new SinglePlayerGame();
        }
    }
}
