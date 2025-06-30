using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FinanceTracker.Domain.Enums;

namespace FinanceTracker.Domain.Models
{
    public class Account : BaseEntity
    {
        [Required]
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public AccountType Type { get; set; }
        
        public virtual User User { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}