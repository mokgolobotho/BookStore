using System.Diagnostics;
using BookStore.Data;
using BookStore.Models;
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
    public IActionResult LoginPost(IFormCollection form)
    {
        string username = form["username"];
        string password = form["password"];
        var user = _context.UsersEntity.FirstOrDefault(u => u.Username == username);
        if (user != null)
        {
            if (user.Password == password)
            {
                return RedirectToAction("Index", "Home");
            }
        }
        ViewData["ErrorMessage"] = "Invalid username or password.";
        return View("Login");
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
        string password
    )
    {
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
            Surname = surname,
            Cellphone = cellphone,
            Email = email,
            Password = password,
        };

        _context.UsersEntity.Add(user);
        _context.SaveChanges();

        return RedirectToAction("Login");
    }
}
