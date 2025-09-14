using Microsoft.AspNetCore.Mvc;

namespace ProductWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Success");
    }
}
