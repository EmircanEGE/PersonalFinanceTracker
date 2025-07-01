using FinanceTracker.Application.DTOs.Transaction;

namespace FinanceTracker.Application.Interfaces.Services
{
    public interface ITransactionService
    {
        Task CreateTransactionAsync(TransactionCreateDto transactionCreateDto);
        Task<TransactionResponseDto> GetTransactionByIdAsync(Guid id);
        Task<IEnumerable<TransactionResponseDto>> GetAllTransactionsAsync();
        Task DeleteTransactionAsync(Guid id);
    }
}