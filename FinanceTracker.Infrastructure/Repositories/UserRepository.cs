using FinanceTracker.Application.Interfaces;
using FinanceTracker.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbSet<User> dbSet, AppDbContext context) : base(dbSet, context)
        {
        }
    }
}