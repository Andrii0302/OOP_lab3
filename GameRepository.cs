
namespace MyGame
{
    // Інтерфейс репозиторія для ігор
    public interface GameInterface
    {
        void CreateGame(GameData game);
        List<GameData> ReadGames();
        List<GameData> ReadPlayerGamesByPlayerId(int playerId);
        void UpdateGame(GameData game);
        void DeleteGameById(int id);
    }

    public class GameRepository : GameInterface
    {
        private readonly DbContext dbContext;

        public GameRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateGame(GameData game)
        {
            game.GameId = dbContext.Games.Count() + 1;
            dbContext.Games.Add(game);
        }

        public void DeleteGameById(int id)
        {
            var game = dbContext.Games.FirstOrDefault(x => x.GameId == id);
            dbContext.Games.Remove(game);
        }

        public List<GameData> ReadGames()
        {
            return dbContext.Games.ToList();
        }

        public List<GameData> ReadPlayerGamesByPlayerId(int playerId)
        {
            return dbContext.Games.Where(g => g.PlayerId == playerId).ToList();
        }

        public void UpdateGame(GameData game)
        {
            var index = dbContext.Games.IndexOf(game);
            dbContext.Games[index] = game;
        }
    }

}
