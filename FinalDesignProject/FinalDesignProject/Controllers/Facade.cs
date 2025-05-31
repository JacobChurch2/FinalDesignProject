using System;
using System.Security.Cryptography.X509Certificates;
using FinalDesignProject.Models;

public class Facade
{
	GameTemplate Template { get; set; }

	public void DoIt()
	{
		bool leave = false;
		do
		{
			Console.WriteLine("Would you like to Save or Load a game? (S/L) Or Quit (Q): ");
			string choice = Console.ReadLine()?.ToLower();
			switch (choice)
			{
				case "s":
					ChooseGame();
					Template.SaveGame();
					break;
				case "l":
					Console.WriteLine("Plase Enter The Save Name (Case Sensitive): ");
					Console.WriteLine(SaveFile.Instance.LoadFromJson(Console.ReadLine()));
					break;
				case "q":
					leave = true;
					Console.WriteLine("Thank you for using the game save system. Goodbye!");
					break;
				default:
					break;

			}
		} while (!leave);
	}

	public void ChooseGame()
	{
		bool validGame = false;
		do
		{
			Console.WriteLine("Please choose a game type (Uno, Phase10, Monopoly): ");
			string gameType = Console.ReadLine();
			validGame = SetGame(gameType);

		} while (!validGame);
	}

	public bool SetGame(string gameType)
	{
		if (string.IsNullOrEmpty(gameType))
		{
			Console.WriteLine("Game type cannot be empty. Please try again.");
			return false;
		}

		switch (gameType.ToLower())
		{
			case "uno":
				Template = new Uno();
				return true;
			case "phase10":
				Template = new Phase10();
				return true;
			case "monopoly":
				Template = new Monopoly();
				return true;
			default:
				return false;
		}
	}
}
