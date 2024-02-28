using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PermissionsTest.AuthPermissions;
using PermissionsTest.Classes;
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
        var permissons = User.Claims.FirstOrDefault(c => c.Type == Constants.PermissionClaimPrefix + "1")?.Value.ResolvePermissions();
        return View();
    }

    [Permission(Permission.WriteThread)]
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
            new(Constants.CurrentCommunityClaim,"1"),
            new(Constants.PermissionClaimPrefix+"1",PermissionExt.CreatePermissionsVector().GrantPermission(Permission.WriteThread).GrantPermission(Permission.ReadThread)),
            new(Constants.PermissionClaimPrefix+"2",PermissionExt.CreatePermissionsVector().GrantPermission(Permission.ReadThread)),
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> SignOutAsync()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("Index");
    }

}
