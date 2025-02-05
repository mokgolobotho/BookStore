using System.ComponentModel.DataAnnotations;

namespace BookStore.Models;

public class BookTypeEntity
{
    public int Id { get; set; }

    [StringLength(100)]
    public required string Type { get; set; }
    public required string Category { get; set; }
}
