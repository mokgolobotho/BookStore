using System.ComponentModel.DataAnnotations;

namespace BookStore.Models;

public class BooksEntity{

    public int Id { set; get; }
    public required string Title { set; get; }
    [StringLength(100)]
    public required string Publisher { set; get; }
    [StringLength(100)]
    public required string Author { set; get; }
    public required string ISBN { set; get; }
    public required string Description { set; get; }
    public required string genre { set; get; }
    public required decimal price { set; get; }

}