using Entities;

namespace Repositories;

public interface IProductRepositories
{
    // Define methods for product-related data access

    List<Product> GetAllProducts();
}