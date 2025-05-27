using System;

namespace FinalDesignProject.Models
{
    public class GameFactory
    {
        public static IGame CreateGame(string gameType)
        {
            return gameType.ToLower() switch
            {
                "monopoly" => new Monopoly(),
                "uno" => new Uno(),
                "phase10" => new Phase10(),
                _ => throw new ArgumentException($"Unknown game type: {gameType}")
            };
        }
    }
} 