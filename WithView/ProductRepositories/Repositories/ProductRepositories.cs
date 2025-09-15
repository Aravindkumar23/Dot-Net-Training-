using Utility;
using Entities;

namespace Repositories;

public class ProductRepositories : IProductRepositories
{
    private readonly string jsonFilePath = FileConstants.ProductDataFilePath;
    private readonly JSONHelperService _jsonHelperService = new JSONHelperService();

    public List<Product> GetAllProducts()
    {

        return _jsonHelperService.LoadFromJsonFile<List<Product>>(jsonFilePath);
    }
}
