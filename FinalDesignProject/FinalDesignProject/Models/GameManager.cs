using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace FinalDesignProject.Models
{
    public class GameManager
    {
        private readonly string saveDirectory;
        private readonly SaveFile saveFile;

        public GameManager()
        {
            saveDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GameSaves");
            Directory.CreateDirectory(saveDirectory);
            saveFile = SaveFile.Instance;
        }

        public void SaveGame(IGame game)
        {
            var gameState = game.GetGameState();
            string json = JsonConvert.SerializeObject(gameState, Formatting.Indented);
            string filePath = Path.Combine(saveDirectory, $"{game.GameName.ToLower()}_save.json");
            File.WriteAllText(filePath, json);
            Console.WriteLine($"Game saved successfully to {filePath}");
        }

        public IGame LoadGame(string gameType)
        {
            string filePath = Path.Combine(saveDirectory, $"{gameType.ToLower()}_save.json");
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"No save file found for {gameType}");
            }

            string json = File.ReadAllText(filePath);
            var gameState = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            
            var game = GameFactory.CreateGame(gameType);
            game.LoadGameState(gameState);
            return game;
        }

        public void StartNewGame()
        {
            Console.WriteLine("Select a game to play:");
            Console.WriteLine("1. Monopoly");
            Console.WriteLine("2. Uno");
            Console.WriteLine("3. Phase 10");
            
            string choice = Console.ReadLine();
            IGame game = choice switch
            {
                "1" => GameFactory.CreateGame("monopoly"),
                "2" => GameFactory.CreateGame("uno"),
                "3" => GameFactory.CreateGame("phase10"),
                _ => throw new ArgumentException("Invalid choice")
            };

            Console.WriteLine($"Starting new game of {game.GameName}");
            // Here you would initialize the game with player information, etc.
            SaveGame(game);
        }
    }
} 