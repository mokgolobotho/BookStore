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
        var books = _context.BooksEntity.ToList();
        return View(books);
    }

    [Authorize(Roles = "Admin")]
    public IActionResult Users()
    {
        var users = _context.UsersEntity.ToList();
        return View(users);
    }
}
