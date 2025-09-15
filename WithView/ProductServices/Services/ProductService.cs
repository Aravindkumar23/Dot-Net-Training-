using Repositories;
using Entities;

namespace LogicServices;


public class ProductService : IProductService
{
    // Implement methods for product-related operations
    private readonly IProductRepositories _ProductRepositories;

    public ProductService(IProductRepositories ProductRepositories)
    {
        _ProductRepositories = ProductRepositories;
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _ProductRepositories.GetAllProducts();
    }
}
