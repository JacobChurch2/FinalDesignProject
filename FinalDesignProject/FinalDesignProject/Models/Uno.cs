using System.Collections.Generic;

namespace FinalDesignProject.Models
{
    class Uno : GameTemplate
    {
		private IGame gameFlyWeight = new IGame();

        public Dictionary<string, int> PlayerPoints { get; set; } = new Dictionary<string, int>();

		protected override void getPlayerInfo()
		{
			gameFlyWeight.SetPlayers();

			foreach (var player in gameFlyWeight.Players)
			{
				// Initialize player points
				bool pointsSet = false;
				do
				{
					Console.WriteLine("Please enter the points for " + player.Trim() + ": ");
					try
					{
						PlayerPoints[player.Trim()] = int.Parse(Console.ReadLine());
						pointsSet = true;
					}
					catch (FormatException)
					{
						Console.WriteLine("Invalid points amount. Setting to 0.");
						PlayerPoints[player.Trim()] = 0;
					}
				} while (!pointsSet);
			}
		}

		protected override void getCurrentPlayer()
		{
			gameFlyWeight.SetCurrentPlayer();
		}

		protected override void getOtherSaveInfo()
		{
			gameFlyWeight.GameName = "Uno";
		}

		public override string ToString()
		{
			return gameFlyWeight.ToString()+
				$"Player Points: {string.Join(", ", PlayerPoints.Select(kv => $"{kv.Key}: {kv.Value}"))} \n";
		}

	}
} 