using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required] [EmailAddress] [MaxLength(255)]
        public string Email { get; set; }
        [Required] [MaxLength(50)]
        public string FirstName { get; set; }
        [Required] [MaxLength(50)]
        public string LastName { get; set; }
        [Required] [MaxLength(100)]
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}