using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public abstract class Game
    {
        public abstract int CountRating(bool winORlose);
    }
    class SinglePlayerGame : Game
    {
        public override int CountRating(bool winORlose)
        {
            return winORlose ? 10 : -10; 
        }
    }

    class TrainingGame : Game
    {
        public override int CountRating(bool winORlose)
        {
            return 0; 
        }
    }

    class StandardGame : Game
    {
        public override int CountRating(bool winORlose)
        {
            return winORlose ? 20 : -20;
        }
    }
}
