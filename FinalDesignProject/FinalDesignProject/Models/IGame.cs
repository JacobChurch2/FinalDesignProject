using System.Collections.Generic;

namespace FinalDesignProject.Models
{
    public interface IGame
    {
        string GameName { get; }
        Dictionary<string, object> GetGameState();
        void LoadGameState(Dictionary<string, object> state);
    }
} 