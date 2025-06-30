using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceTracker.Domain.Models
{
    public class Budget : BaseEntity
    {
        [Required]
        [ForeignKey(nameof(Category))]
        public Guid CategoryId { get; set; }
        [Required]
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        [Required]
        public int Month { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public int Limit { get; set; }
    }
}