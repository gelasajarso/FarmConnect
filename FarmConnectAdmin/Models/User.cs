using System.ComponentModel.DataAnnotations;

namespace FarmConnectAdmin.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public required string FullName { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required string Role { get; set; }

        // ✅ NULL-SAFE
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
