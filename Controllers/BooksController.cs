using System.Diagnostics;
using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers;

public class BooksController : Controller
{
    private AppDbContext _context;

    public BooksController(AppDbContext context)
    {
        _context = context;
    }

    [Authorize]
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
    public IActionResult AddBook(BooksEntity book, IFormFile file)
    {
        Console.WriteLine(file.FileName);
        string extension = Path.GetExtension(file.FileName);

        var validExtensions = new[] { ".jpg", ".jpeg", ".png", ".webp" };
        if (validExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase))
        {
            string fileName = Guid.NewGuid().ToString() + extension;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
            string pathName = Path.Combine(path, fileName);
            using FileStream stream = new FileStream(pathName, FileMode.Create);

            file.CopyTo(stream);

            book.ImageUrl = "/images/" + fileName;
            _context.BooksEntity.Add(book);
            _context.SaveChanges();
            Console.WriteLine(User.Identity?.IsAuthenticated ?? false);
            return RedirectToAction("Index", "Home");
        }
        return View("Create");
    }
}
