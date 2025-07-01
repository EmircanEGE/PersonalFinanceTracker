using FinanceTracker.Domain.Enums;

namespace FinanceTracker.Application.DTOs.Account
{
    public class AccountCreateDto
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public AccountType Type { get; set; }
    }
}