using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductApplication.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Authentication;

namespace ProductApplication.Controllers;

public class AuthController : Controller
{
    private readonly ILogger<AuthController> _logger;
    private readonly IUserFinder _userFinder;

    public AuthController(ILogger<AuthController> logger, IUserFinder userFinder)
    {
        _logger = logger;
        _userFinder = userFinder;
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
     public async Task<IActionResult> Login(string email, string password)
    {

        // if (email == "aravindkumar@test.com" && password == "black")
        // {
        //     this.Response.Redirect("/home/index");
        // }

         var user = _userFinder.Validate(email,password);
            if (user != null)
            {
                // Create a claims identity
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, email)
                    };


                var claimsIdentity = new ClaimsIdentity(claims, 
                                                        CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                // Sign in the user
               await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                             claimsPrincipal);

                return RedirectToAction("Index", "Home");
            }
         
        return View();
    }
}
