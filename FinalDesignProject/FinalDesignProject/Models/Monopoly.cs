using System.Collections.Generic;

namespace FinalDesignProject.Models
{
	class Monopoly : GameTemplate
	{
		private IGame gameFlyWeight = new IGame();
		public Dictionary<string, int> PlayerMoney { get; set; } = new Dictionary<string, int>();
		public Dictionary<string, List<string>> PlayerProperties { get; set; } = new Dictionary<string, List<string>>();

		protected override void getPlayerInfo()
		{
			gameFlyWeight.SetPlayers();
			foreach (var player in gameFlyWeight.Players)
			{
				// Initialize player money and properties
				bool moneySet = false;
				do
				{
					Console.WriteLine("Please enter the money amount for " + player.Trim() + ": ");
					try
					{
						PlayerMoney[player.Trim()] = int.Parse(Console.ReadLine());
						moneySet = true;
					}
					catch (FormatException)
					{
						Console.WriteLine("Invalid money amount. Setting to 0.");
						PlayerMoney[player.Trim()] = 0;
					}
				} while (!moneySet);

				Console.WriteLine("Please enter the properties for " + player.Trim() + " (comma separated) (Leave Blank if None): ");
				List<string> properties = new List<string>(Console.ReadLine().Split(','));
				PlayerProperties[player.Trim()] = properties;
			}
		}



		protected override void getCurrentPlayer()
		{
			gameFlyWeight.SetCurrentPlayer();
		}

		protected override void getOtherSaveInfo()
		{
			gameFlyWeight.GameName = "Monopoly";
		}

		public override string ToString()
		{
			return gameFlyWeight.ToString() +
				$"Player Money: {string.Join(", ", PlayerMoney.Select(kv => $"{kv.Key}: {kv.Value}"))}, \n" +
				$"Player Properties: {string.Join(", ", PlayerProperties.Select(kv => $"{kv.Key}: [{string.Join(", ", kv.Value)}]"))}\n";
		}
	}
}