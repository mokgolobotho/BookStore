using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models;

public class BooksEntity
{
    public int Id { set; get; }
    public required string Title { set; get; }

    [StringLength(100)]
    public required string Publisher { set; get; }

    [StringLength(100)]
    public required string Author { set; get; }
    public required string ImageUrl { set; get; }
    public required string ISBN { set; get; }
    public required string Description { set; get; }
    public required string Genre { set; get; }

    [Column(TypeName = "decimal(18,2)")]
    public required decimal Price { set; get; }
}
