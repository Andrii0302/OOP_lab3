namespace MyGame
{
    // Сутність гравця
    public class Player
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public int CurrentRating { get; set; }
        public List<GameData> Games { get; set; } = new List<GameData>();
    }
}
