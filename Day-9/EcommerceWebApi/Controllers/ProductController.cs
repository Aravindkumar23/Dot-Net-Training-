using Microsoft.AspNetCore.Mvc;
namespace EcommerceWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private static readonly List<object> Products = new()
        {
            new { Id = 1, Name = "Laptop", Price = 1200 },
            new { Id = 2, Name = "Headphones", Price = 150 },
            new { Id = 3, Name = "Keyboard", Price = 75 }
        };

    // GET: api/products
    [HttpGet]
    public IActionResult GetProducts()
    {
        return Ok(Products);
    }

    // GET: api/products/1
    [HttpGet("{id}")]
    public IActionResult GetProduct(int id)
    {
        var product = Products.FirstOrDefault(p => (int)p.GetType().GetProperty("Id")!.GetValue(p)! == id);

        if (product == null)
            return NotFound();

        return Ok(product);
    }
}
