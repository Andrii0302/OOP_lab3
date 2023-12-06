namespace MyGame
{
    // Інтерфейс репозиторія для гравців
    public interface PlayerInterface
    {
        void CreatePlayer(Player player);
        List<Player> ReadPlayers();
        Player ReadPlayerById(int playerId);
        void UpdatePlayer(Player player);
        void DeletePlayerById(int playerId);
    }
    public class PlayerRepository : PlayerInterface
    {
        private readonly DbContext dbContext;

        public PlayerRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreatePlayer(Player player)
        {
            player.PlayerId = dbContext.Players.Count() + 1;
            dbContext.Players.Add(player);
        }

        public List<Player> ReadPlayers()
        {
            return dbContext.Players.ToList();
        }

        public Player ReadPlayerById(int playerId)
        {
            return dbContext.Players.FirstOrDefault(p => p.PlayerId == playerId);
        }

        public void UpdatePlayer(Player player)
        {
            var index = dbContext.Players.IndexOf(player);
            dbContext.Players[index] = player;
        }

        public void DeletePlayerById(int playerId)
        {
            var player = dbContext.Players.FirstOrDefault(x => x.PlayerId == playerId);
            dbContext.Players.Remove(player);
        }
    }
}