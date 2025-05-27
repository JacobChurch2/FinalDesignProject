using System.Collections.Generic;

namespace FinalDesignProject.Models
{
    public class Phase10 : IGame
    {
        public string GameName => "Phase10";
        public int CurrentPlayer { get; set; }
        public List<string> Players { get; set; } = new List<string>();
        public Dictionary<string, int> PlayerPhases { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, List<string>> PlayerCards { get; set; } = new Dictionary<string, List<string>>();
        public List<string> Deck { get; set; } = new List<string>();
        public string DiscardPile { get; set; }

        public Dictionary<string, object> GetGameState()
        {
            return new Dictionary<string, object>
            {
                { "CurrentPlayer", CurrentPlayer },
                { "Players", Players },
                { "PlayerPhases", PlayerPhases },
                { "PlayerCards", PlayerCards },
                { "Deck", Deck },
                { "DiscardPile", DiscardPile }
            };
        }

        public void LoadGameState(Dictionary<string, object> state)
        {
            CurrentPlayer = (int)state["CurrentPlayer"];
            Players = (List<string>)state["Players"];
            PlayerPhases = (Dictionary<string, int>)state["PlayerPhases"];
            PlayerCards = (Dictionary<string, List<string>>)state["PlayerCards"];
            Deck = (List<string>)state["Deck"];
            DiscardPile = (string)state["DiscardPile"];
        }
    }
} 