using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.Domain.Models
{
    public class User : BaseEntity
    {
        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(100)]
        public string PasswordHash { get; set; }

        public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
        public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
        public virtual ICollection<Budget> Budgets { get; set; } = new List<Budget>();
    }
}