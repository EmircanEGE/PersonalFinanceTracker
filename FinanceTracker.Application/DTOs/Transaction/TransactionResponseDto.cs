using FinanceTracker.Domain.Enums;

namespace FinanceTracker.Application.DTOs.Transaction
{
    public class TransactionResponseDto
    {
        public Guid AccountId { get; set; }
        public Guid CategoryId { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;
        public TransactionType Type { get; set; }
    }
}