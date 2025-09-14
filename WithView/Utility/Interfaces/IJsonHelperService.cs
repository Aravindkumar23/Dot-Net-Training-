namespace Utility;

public interface IJsonHelperService
{
    public string SerializeToJson<T>(T obj);
    public T DeserializeFromJson<T>(string jsonString);
    public void SaveToJsonFile<T>(T obj, string filePath);
    public T LoadFromJsonFile<T>(string filePath);
}