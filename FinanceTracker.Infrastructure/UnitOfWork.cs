using FinanceTracker.Application.Interfaces;
using FinanceTracker.Application.Interfaces.Repositories;
using FinanceTracker.Domain.Models;
using FinanceTracker.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Dictionary<Type, object> _repositories;
        private IUserRepository _userRepository;
        private IAccountRepository _accountRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
            _userRepository = new UserRepository(_context);
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            var type = typeof(TEntity);

            if (!_repositories.ContainsKey(type))
            {
                _repositories[type] = new Repository<TEntity>(_context);
            }

            return (IRepository<TEntity>)_repositories[type];
        }

        public IUserRepository UserRepository => 
            _userRepository ??= new UserRepository(_context);

        public IAccountRepository AccountRepository => 
            _accountRepository ??= new AccountRepository(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Rollback()
        {
            _context.ChangeTracker.Entries()
            .Where(e => e.Entity != null)
            .ToList()
            .ForEach(e => e.State = EntityState.Detached);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}