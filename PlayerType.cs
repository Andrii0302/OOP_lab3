using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{

    class Warrior : ChangedRating_Type
    {
        public int ChangedRating(bool winORlose)
        {
            return winORlose ? 0 : 0;
        }
    }

    class Assassin : ChangedRating_Type
    {
        public int ChangedRating(bool winORlose)
        {
            return winORlose ? 0 : -40; 
        }
    }

    class HollowKnight : ChangedRating_Type
    {
        private int WinsInRow = 0;

        public int ChangedRating(bool winORlose)
        {
            if (winORlose)
            {
                WinsInRow++;
                return WinsInRow * 20; 
            }
            else
            {
                WinsInRow = 0; 
                return -50;
            }
        }
    }
}
