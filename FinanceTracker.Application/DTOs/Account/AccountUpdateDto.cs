using FinanceTracker.Domain.Enums;

namespace FinanceTracker.Application.DTOs.Account
{
    public class AccountUpdateDto
    {
        public string? Name { get; set; }
        public AccountType? Type { get; set; }
    }
}