using FinanceTracker.Application.DTOs.Account;

namespace FinanceTracker.Application.Interfaces.Services
{
    public interface IAccountService
    {
        Task CreateAccountAsync(AccountCreateDto accountCreateDto);
        Task<AccountResponseDto> GetAccountByIdAsync(Guid id);
        Task<IEnumerable<AccountResponseDto>> GetAllAccountsAsync();
        Task DeleteAccountAsync(Guid id);
    }
}