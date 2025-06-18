using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}