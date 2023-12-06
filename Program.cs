using System;
using System.Collections.Generic;


namespace MyGame
{
    interface ChangedRating_Type
    {
        int ChangedRating(bool isWin);
    } 

    class Program
    {
        static void Main()
        {
            var dbContext = new DbContext();
            var playerRepository = new PlayerRepository(dbContext);
            var gameRepository = new GameRepository(dbContext);
            var playerService = new PlayerService(playerRepository);
            var gameService = new GameService(gameRepository);

            playerService.CreatePlayer("Alice", 500);
            playerService.CreatePlayer("Bob", 600);
            playerService.CreatePlayer("Charlie", 700);

            Console.WriteLine("Players:");
            foreach (var player in playerService.GetPlayers())
            {
                Console.WriteLine($"{player.PlayerId}. {player.PlayerName} - {player.CurrentRating}");
            }
            gameService.PlayGame(playerService.GetPlayerById(1), GameFactory.CreateStandardGame(), "opponent", true);
            gameService.PlayGame(playerService.GetPlayerById(1), GameFactory.CreateSinglePlayerGame(), "Bot", true);
            gameService.PlayGame(playerService.GetPlayerById(1), GameFactory.CreateSinglePlayerGame(), "Bot", false);
            gameService.PlayGame(playerService.GetPlayerById(2), GameFactory.CreateTrainingGame(), "Pyk", true);
            gameService.PlayGame(playerService.GetPlayerById(2), GameFactory.CreateTrainingGame(), "Pipi", false);
            gameService.PlayGame(playerService.GetPlayerById(3), GameFactory.CreateStandardGame(), "JEB", false);


            var alice = playerService.GetPlayerById(1);
            Console.WriteLine($"\nGame history for {alice.PlayerName}:");
            Console.WriteLine("Opponent     Status    Points    Game Count");
            foreach (var game in gameService.GetPlayerGames(alice.PlayerId))
            {
                Console.WriteLine($"{game.OpponentName,-12} {game.Result,-9} {game.Points,-9} {game.GameId}");
            }
            Console.WriteLine($"Current Rating: {alice.CurrentRating}\n");



            var bob = playerService.GetPlayerById(2);
            Console.WriteLine($"\nGame history for {bob.PlayerName}:");
            Console.WriteLine("Opponent     Status    Points    Game Count");
            foreach (var game in gameService.GetPlayerGames(bob.PlayerId))
            {
                Console.WriteLine($"{game.OpponentName,-12} {game.Result,-9} {game.Points,-9} {game.GameId}");
            }
            Console.WriteLine($"Current Rating: {bob.CurrentRating}\n");


            var charlie = playerService.GetPlayerById(3);
            Console.WriteLine($"\nGame history for {charlie.PlayerName}:");
            Console.WriteLine("Opponent     Status    Points    Game Count");
            foreach (var game in gameService.GetPlayerGames(charlie.PlayerId))
            {
                Console.WriteLine($"{game.OpponentName,-12} {game.Result,-9} {game.Points,-9} {game.GameId}");
            }
            Console.WriteLine($"Current Rating: {charlie.CurrentRating}\n");


            // Вивід всіх ігор
            Console.WriteLine("\nAll Games:");
            Console.WriteLine("Player 1   Player 2   Status    Points");
            foreach (var game in gameService.GetAllGames())
            {
                Console.WriteLine($"{playerService.GetPlayerById(game.PlayerId).PlayerName, 8} {game.OpponentName, 8} {game.Result, 9} {game.Points, 10}");
            }

        }
        
    }
}