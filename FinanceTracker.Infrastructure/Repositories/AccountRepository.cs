using FinanceTracker.Application.Interfaces.Repositories;
using FinanceTracker.Domain.Enums;
using FinanceTracker.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Infrastructure.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        private readonly DbSet<Account> _dbSet;
        public AccountRepository(AppDbContext context) : base(context)
        {
            _dbSet = context.Set<Account>();
        }

        public async Task<IEnumerable<Account>> GetAccountsByUserIdAsync(Guid userId)
        {
            return await _dbSet
                .Where(a => a.UserId == userId)
                .OrderBy(a => a.Name)
                .ToListAsync();
        }

        public async Task<bool> IsAccountNameTakenAsync(Guid userId, string accountName)
        {
            return await _dbSet
                .AnyAsync(a => a.UserId == userId && a.Name == accountName);
        }

        public async Task<IEnumerable<Account>> GetAccountsByTypeAsync(AccountType accountType)
        {
            return await _dbSet
                .Where(a => a.Type == accountType)
                .OrderBy(a => a.Name)
                .ToListAsync();
        }
    }
}