using Entities;

namespace LogicServices;

public interface IProductService
{
    // Define methods for product-related operations
    IEnumerable<Product> GetAllProducts();
}