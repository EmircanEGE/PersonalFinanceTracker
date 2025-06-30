using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FinanceTracker.Domain.Enums;

namespace FinanceTracker.Domain.Models
{
    public class Transaction : BaseEntity
    {
        [Required]
        [ForeignKey(nameof(Account))]
        public Guid AccountId { get; set; }
        [Required]
        [ForeignKey(nameof(Category))]
        public Guid CategoryId { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Amount { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [MaxLength(200)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public TransactionType Type { get; set; }
        
        public virtual Account Account { get; set; }
        public virtual Category Category { get; set; }
    }
}