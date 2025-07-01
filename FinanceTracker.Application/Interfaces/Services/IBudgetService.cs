using FinanceTracker.Application.DTOs.Budget;

namespace FinanceTracker.Application.Interfaces.Services
{
    public interface IBudgetService
    {
        Task CreateBudgetAsync(BudgetCreateDto budgetCreateDto);
        Task<BudgetResponseDto> GetBudgetByIdAsync(Guid id);
        Task<IEnumerable<BudgetResponseDto>> GetAllBudgetsAsync();
    }
}