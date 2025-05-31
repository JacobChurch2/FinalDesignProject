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
	}

	private string filePath = AppDomain.CurrentDomain.BaseDirectory + "saveFiles/";

	public void SaveToJson(string data, string saveFileName)
	{
		string json = JsonConvert.SerializeObject(data, Formatting.Indented);

		if (!Directory.Exists(filePath))
		{
			Directory.CreateDirectory(filePath);
		}
		File.WriteAllText(filePath + saveFileName, json);
	}

	public string LoadFromJson(string saveFileName)
	{
		if(!File.Exists(filePath + saveFileName))
			return "Save file not found.";

		string json = File.ReadAllText(filePath + saveFileName);
		var parsedString = JsonConvert.DeserializeObject<string>(json);
		return parsedString;
	}

}
