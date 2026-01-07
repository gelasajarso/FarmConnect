using System.ComponentModel.DataAnnotations;

public class Admin
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public required string Username { get; set; }

    [Required]
    [MaxLength(100)]
    public required string Password { get; set; }
}
