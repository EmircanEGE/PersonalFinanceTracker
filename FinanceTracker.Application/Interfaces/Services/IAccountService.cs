using FinanceTracker.Application.DTOs.Account;
using FinanceTracker.Domain.Enums;

namespace FinanceTracker.Application.Interfaces.Services
{
    public interface IAccountService
    {
        Task CreateAccountAsync(AccountCreateDto accountCreateDto);
        Task<AccountResponseDto> GetAccountByIdAsync(Guid id);
        Task<IEnumerable<AccountResponseDto>> GetAllAccountsAsync();
        Task DeleteAccountAsync(Guid id);
        Task<AccountResponseDto> UpdateAccountAsync(Guid id, AccountUpdateDto accountUpdateDto);
        Task<IEnumerable<AccountResponseDto>> GetAccountsByTypeAsync(AccountType type);
    }
}