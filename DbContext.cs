

namespace MyGame
{
    public class DbContext
    {
        public List<Player> Players { get; set; } = new List<Player>();
        public List<GameData> Games { get; set; } = new List<GameData>();
    }

}