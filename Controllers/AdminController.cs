using System.Diagnostics;
using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers;

public class AdminController : Controller
{
    public AppDbContext _context;

    public AdminController(AppDbContext context)
    {
        _context = context;
    }

    [Authorize(Roles = "Admin")]
    public IActionResult AdminHome()
    {
        Console.WriteLine(User.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value);
        Console.Write("debug");
        var books = _context.BooksEntity.ToList();
        return View(books);
    }
}
