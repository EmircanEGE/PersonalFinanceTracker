using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.Domain.Models
{
    public abstract class BaseEntity
    {
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Required]
        public DateTime? UpdatedAt { get; set; } = null;
    }
}