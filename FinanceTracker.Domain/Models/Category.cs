using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FinanceTracker.Domain.Enums;

namespace FinanceTracker.Domain.Models
{
    public class Category : BaseEntity
    {
        [Required]
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public CategoryType Type { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        public virtual ICollection<Budget> Budgets { get; set; } = new List<Budget>();
    }
}