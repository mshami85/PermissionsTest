using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PermissionsTest.AuthPermissions;
using PermissionsTest.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace PermissionsTest.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.State = User.Identity?.IsAuthenticated ?? false ? "Hooooorrrrrrraaaaayyyyyyyyy Logged in" : "Logged out";
        return View();
    }

    [Permission(Permission.CreateThread)]
    public IActionResult Privacy()
    {
        var user = User;
        return View();
    }

    [Authorize]
    public IActionResult Test()
    {
        return View();
    }

    public async Task<IActionResult> Signin()
    {

        // In a real-world application, user credentials would need validated before signing in
        var claims = new List<Claim>
        {
            // Add a Name claim and, if birth date was provided, a DateOfBirth claim
            new(ClaimTypes.Name, "SHAMI"),
            new(ClaimTypes.Role, "Admin"),
            new("PermissionFor1", "100011"),
            new("PermissionFor2", "000000"),
            new("PermissionFor3", "000000"),
            new("Community","2")
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

        var test = User.Identity;

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> SignOutAsync()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("Index");
    }

}
