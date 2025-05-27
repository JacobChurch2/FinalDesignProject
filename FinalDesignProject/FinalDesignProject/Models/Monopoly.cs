using System.Collections.Generic;

namespace FinalDesignProject.Models
{
    public class Monopoly : IGame
    {
        public string GameName => "Monopoly";
        public int CurrentPlayer { get; set; }
        public List<string> Players { get; set; } = new List<string>();
        public Dictionary<string, int> PlayerMoney { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, List<string>> PlayerProperties { get; set; } = new Dictionary<string, List<string>>();

        public Dictionary<string, object> GetGameState()
        {
            return new Dictionary<string, object>
            {
                { "CurrentPlayer", CurrentPlayer },
                { "Players", Players },
                { "PlayerMoney", PlayerMoney },
                { "PlayerProperties", PlayerProperties }
            };
        }

        public void LoadGameState(Dictionary<string, object> state)
        {
            CurrentPlayer = (int)state["CurrentPlayer"];
            Players = (List<string>)state["Players"];
            PlayerMoney = (Dictionary<string, int>)state["PlayerMoney"];
            PlayerProperties = (Dictionary<string, List<string>>)state["PlayerProperties"];
        }
    }
} 