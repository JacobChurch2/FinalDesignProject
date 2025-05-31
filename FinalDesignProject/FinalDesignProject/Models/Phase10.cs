using System.Collections.Generic;

namespace FinalDesignProject.Models
{
    class Phase10 : GameTemplate
    {
		private IGame gameFlyWeight = new IGame();
        public Dictionary<string, int> PlayerPhases { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, int> PlayerPoints { get; set; } = new Dictionary<string, int>();

        protected override void getPlayerInfo()
        {
            gameFlyWeight.SetPlayers();

			foreach (var player in gameFlyWeight.Players)
			{
				// Initialize player phases and points
				bool phaseSet = false;
				do
				{
					Console.WriteLine("Please enter the phase number for " + player.Trim() + " (1-10): ");
					try
					{
						int phase = int.Parse(Console.ReadLine());
						if (phase >= 1 && phase <= 10)
						{
							PlayerPhases[player.Trim()] = phase;
							phaseSet = true;
						}
						else
						{
							Console.WriteLine("Invalid phase number. Please enter a number between 1 and 10.");
						}
					}
					catch (FormatException)
					{
						Console.WriteLine("Invalid input. Setting phase to 1.");
						PlayerPhases[player.Trim()] = 1;
					}
				} while (!phaseSet);
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
			gameFlyWeight.GameName = "Phase10";
		}

		public override string ToString()
		{
			return gameFlyWeight.ToString() +
				   $"Player Phases: {string.Join(", ", PlayerPhases)}; \n" +
				   $"Player Points: {string.Join(", ", PlayerPoints)} \n";
		}
	}
} 