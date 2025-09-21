using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Authentication;

namespace ProductApplication.Controllers;

public class AuthController : Controller
{
    private readonly IUserFinder _userFinder;

    public AuthController(IUserFinder userFinder)
    {
        _userFinder = userFinder;
    }

    // public IActionResult Index()
    // {
    //     return View();
    // }

    // public IActionResult Login()
    // {
    //     return View();
    // }

    [HttpPost("login")]
public async Task<IActionResult> Login(string email, string password)
{
    var user = _userFinder.Validate(email, password);
    if (user != null)
    {
        // Create claims
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, email)
        };

        var claimsIdentity = new ClaimsIdentity(
            claims, CookieAuthenticationDefaults.AuthenticationScheme);

        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

        // Sign in - this will create and send the cookie to client
        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            claimsPrincipal,
            new AuthenticationProperties
            {
                IsPersistent = true, // cookie persists across sessions
                ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1) // expiry
            });

        return Ok(new { message = "Login successful" });
    }

    return Unauthorized(new { message = "Invalid credentials" });
}

}
