using System.Diagnostics;
using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers;

public class BooksController : Controller
{
    private AppDbContext _context;

    public BooksController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var books = _context.BooksEntity.ToList();
        return View(books);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddBook(BooksEntity book)
    {
        _context.BooksEntity.Add(book);
        _context.SaveChanges();
        return RedirectToAction("Index", "Home");
    }
}
