namespace Utility;

public class JSONHelperService : IJsonHelperService
{
    public string SerializeToJson<T>(T obj)
    {
        return System.Text.Json.JsonSerializer.Serialize(obj);
    }

    public T DeserializeFromJson<T>(string jsonString)
    {
        return System.Text.Json.JsonSerializer.Deserialize<T>(jsonString)
            ?? throw new ArgumentException("Failed to deserialize JSON");
    }

    public void SaveToJsonFile<T>(T obj, string filePath)
    {
        string jsonString = SerializeToJson(obj);
        File.WriteAllText(filePath, jsonString);
    }

    public T LoadFromJsonFile<T>(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException($"JSON file not found: {filePath}");

        string jsonString = File.ReadAllText(filePath);
        return DeserializeFromJson<T>(jsonString);
    }
}
