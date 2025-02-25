using System.Diagnostics;
using System.Security.Claims;
using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers;

public class AuthenticationController : Controller
{
    private AppDbContext _context;
    private readonly ILogger<AuthenticationController> _logger;

    public AuthenticationController(AppDbContext context, ILogger<AuthenticationController> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> LoginPost(IFormCollection form)
    {
        string username = form["username"];
        string password = form["password"];
        var user = _context.UsersEntity.FirstOrDefault(u => u.Username == username);
        if (user != null)
        {
            if (user.Password == password)
            {
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, user.Username));
                claims.Add(new Claim(ClaimTypes.Email, user.Email));

                if (user.Role == "Admin")
                {
                    claims.Add(new Claim(ClaimTypes.Role, user.Role));
                    SetCookies(claims);
                    return RedirectToAction("AdminHome", "Admin");
                }
                SetCookies(claims);
                return RedirectToAction("Index", "Home");
            }
        }
        ViewData["ErrorMessage"] = "Invalid username or password.";
        Console.Write(user.Role);

        return View("Login");
    }

    public async Task SetCookies(List<Claim> claim)
    {
        var claims = claim;
        var claimsIdentity = new ClaimsIdentity(
            claims,
            CookieAuthenticationDefaults.AuthenticationScheme
        );
        var principal = new ClaimsPrincipal(claimsIdentity);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(
        string name,
        string surname,
        string cellphone,
        string email,
        string role,
        string password
    )
    {
        Console.WriteLine(role);
        var user1 = _context.UsersEntity.FirstOrDefault(u => u.Username == email);
        if (user1 != null)
        {
            ViewData["ErrorMessage"] = "User email already exits";
            return View();
        }
        var user = new UsersEntity
        {
            Username = email,
            Name = name,
            Role = role,
            Surname = surname,
            Cellphone = cellphone,
            Email = email,
            Password = password,
        };

        _context.UsersEntity.Add(user);
        _context.SaveChanges();

        return RedirectToAction("Login");
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login");
    }
}
