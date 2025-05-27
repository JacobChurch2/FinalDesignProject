using Newtonsoft.Json; // Ensure you have the Newtonsoft.Json package installed
using System.IO;

public sealed class SaveFile
{
	private static SaveFile instance;

	public static SaveFile Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new SaveFile();
			}
			return instance;
		}
	}

	private SaveFile()
	{
		// Constructor logic here
		if (!File.Exists(filePath))
		{
			File.WriteAllText(filePath, "{}"); // Empty JSON object
		}
	}

	private string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "levelHighScores.json");

	public void SaveToJson(string course, string levelName, int score)
	{
		var data = LoadAllScores();
		if (data == null)
		{
			data = new Dictionary<string, Dictionary<string, int>>();
		}

		if (!data.ContainsKey(course))
		{
			data[course] = new Dictionary<string, int>();
		}

		if (!data[course].ContainsKey(levelName))
		{
			data[course][levelName] = 0;
		}

		int existingScore;
		existingScore = data[course][levelName];
		if (existingScore > score || existingScore == 0)
		{
			data[course][levelName] = score;
			string json = JsonConvert.SerializeObject(data, Formatting.Indented);
			File.WriteAllText(filePath, json);
		}
		else
		{
			Console.WriteLine("Score not saved, existing score is lower.");
		}
	}

	public Dictionary<string, Dictionary<string, int>> LoadAllScores()
	{
		if (!File.Exists(filePath))
			return new Dictionary<string, Dictionary<string, int>>();

		string json = File.ReadAllText(filePath);
		Dictionary<string, Dictionary<string, int>> data = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, int>>>(json);
		if (data == null) data = new Dictionary<string, Dictionary<string, int>>();
		return data;
	}

	public int LoadFromJson(string course, string levelName)
	{
		var data = LoadAllScores();
		if (!data.ContainsKey(course))
			return 0;
		if (!data[course].ContainsKey(levelName))
			return 0;
		return data[course][levelName];
	}

}
