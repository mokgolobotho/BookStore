using System.ComponentModel.DataAnnotations;

namespace BookStore.Models;

public class UsersEntity
{
    public int Id { set; get; }

    [StringLength(100)]
    public required string Username { set; get; }

    [StringLength(100)]
    public required string Name { set; get; }

    public string? Role { set; get; }
    public required string Surname { set; get; }
    public required string Password { set; get; }
    public string? Cellphone { set; get; }
    public string? Email { set; get; }
}
