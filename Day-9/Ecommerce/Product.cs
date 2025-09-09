using System.Collections.Generic;
using System.Linq;

namespace Ecommerce {
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }

        private static List<Product> products = new()
        {
            new Product { Id = 1, Name = "Laptop", Price = 1200 },
            new Product { Id = 2, Name = "Headphones", Price = 150 },
            new Product { Id = 3, Name = "Keyboard", Price = 75 }
        };

        public static List<Product> GetAllProducts() => products;

        public static Product? GetProductById(int id) => products.FirstOrDefault(p => p.Id == id);

        public static void AddProduct(Product product) {
            if (products.Any(p => p.Id == product.Id && product.Price > 100)){
                ApplyPriceDiscount(product,15);
            } else if (products.Any(p => p.Id == product.Id && product.Price > 50)){
                ApplyPriceDiscount(product,5);
            }
            products.Add(product);
        }

        public static bool RemoveProduct(int id)
        {
            var product = GetProductById(id);
            if (product == null) return false;
            products.Remove(product);
            return true;
        }

        public static void ApplyPriceDiscount(Product product,decimal percentage)
        {
            if (percentage < 0 || percentage > 100)
                throw new ArgumentOutOfRangeException(nameof(percentage), "Percentage must be between 0 and 100.");
            product.Price -= product.Price * (percentage / 100);
        }
    }
}