using System.Collections.Generic;

namespace FinalDesignProject.Models
{
    public class Uno : IGame
    {
        public string GameName => "Uno";
        public int CurrentPlayer { get; set; }
        public List<string> Players { get; set; } = new List<string>();
        public Dictionary<string, List<string>> PlayerCards { get; set; } = new Dictionary<string, List<string>>();
        public List<string> Deck { get; set; } = new List<string>();
        public string CurrentCard { get; set; }

        public Dictionary<string, object> GetGameState()
        {
            return new Dictionary<string, object>
            {
                { "CurrentPlayer", CurrentPlayer },
                { "Players", Players },
                { "PlayerCards", PlayerCards },
                { "Deck", Deck },
                { "CurrentCard", CurrentCard }
            };
        }

        public void LoadGameState(Dictionary<string, object> state)
        {
            CurrentPlayer = (int)state["CurrentPlayer"];
            Players = (List<string>)state["Players"];
            PlayerCards = (Dictionary<string, List<string>>)state["PlayerCards"];
            Deck = (List<string>)state["Deck"];
            CurrentCard = (string)state["CurrentCard"];
        }
    }
} 