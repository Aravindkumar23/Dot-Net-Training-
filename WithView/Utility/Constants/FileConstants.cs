namespace Utility;

public class FileConstants
{
    public static readonly string ProductDataFilePath = Path.Combine(AppContext.BaseDirectory, "JsonFiles", "product.json");
    public static readonly string UserDataFilePath = Path.Combine(AppContext.BaseDirectory, "JsonFiles", "users.json");
}