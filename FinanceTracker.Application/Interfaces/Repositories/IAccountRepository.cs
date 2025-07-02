using FinanceTracker.Domain.Enums;
using FinanceTracker.Domain.Models;

namespace FinanceTracker.Application.Interfaces.Repositories
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<IEnumerable<Account>> GetAccountsByUserIdAsync(Guid userId);
        Task<bool> IsAccountNameTakenAsync(Guid userId, string accountName);
        Task<IEnumerable<Account>> GetAccountsByTypeAsync(AccountType accountType);
    }
}