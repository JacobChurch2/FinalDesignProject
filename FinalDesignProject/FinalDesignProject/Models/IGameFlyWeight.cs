using System.Collections.Generic;

namespace FinalDesignProject.Models
{
    public class IGame
    {
        public string GameName { get; set; }
        public int CurrentPlayer { get; set; }
		public List<string> Players { get; set; }

        public override string ToString()
		{
			return GameName + " Game State: \n" +
				$"Current Player: {CurrentPlayer}, \n" +
				$"Players: {string.Join(", ", Players)} \n";
		}

		public void SetPlayers()
		{
			bool playersSet = false;
			do
			{
				Console.WriteLine("Please Enter Player Names (comma separated): ");
				string input = Console.ReadLine();
				if (!string.IsNullOrEmpty(input))
				{
					playersSet = true;
					Players = new List<string>(input.Split(','));
				}
			} while (!playersSet);
		}

		public void SetCurrentPlayer()
		{
			bool validInput = false;
			int currentPlayerIndex = 0;
			do
			{
				Console.WriteLine("Please enter the index of the current player (1 to " + Players.Count + "): ");
				string input = Console.ReadLine();
				try
				{
					currentPlayerIndex = int.Parse(input) - 1;
					if (currentPlayerIndex >= 0 && currentPlayerIndex < Players.Count)
					{
						validInput = true;
						CurrentPlayer = currentPlayerIndex;
					}
					else
					{
						Console.WriteLine("Invalid index. Please enter a number between 1 and " + Players.Count + ".");
					}
				}
				catch (FormatException)
				{
					Console.WriteLine("Invalid input. Please enter a valid number.");
				}
			} while (!validInput);
		}
	}
} 