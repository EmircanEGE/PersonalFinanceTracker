using FinanceTracker.Application.Interfaces.Repositories;
using FinanceTracker.Domain.Models;

namespace FinanceTracker.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        IUserRepository UserRepository { get; }
        IAccountRepository AccountRepository { get; }
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        void Rollback();
    }
}