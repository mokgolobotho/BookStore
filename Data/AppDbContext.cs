namespace BookStore.Data;

using BookStore.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<BooksEntity> BooksEntity { get; set; }
    public DbSet<UsersEntity> UsersEntity { get; set; }
}
