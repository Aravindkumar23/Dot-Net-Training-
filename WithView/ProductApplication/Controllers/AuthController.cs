using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductApplication.Models;

namespace ProductApplication.Controllers;

public class AuthController : Controller
{
    private readonly ILogger<AuthController> _logger;

    public AuthController(ILogger<AuthController> logger)
    {
        _logger = logger;
    }

    // public IActionResult Index()
    // {
    //     return View();
    // }

    public IActionResult Login()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }



    [HttpPost]
     public IActionResult Login(string email, string password)
    {

        if (email == "aravindkumar@test.com" && password == "black")
        {
            this.Response.Redirect("/home/index");
        }
         
        return View();
    }
}
