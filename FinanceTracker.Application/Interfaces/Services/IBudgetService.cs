using FinanceTracker.Application.DTOs.Budget;

namespace FinanceTracker.Application.Interfaces.Services
{
    public interface IBudgetService
    {
        Task<BudgetResponseDto> CreateBudgetAsync(BudgetCreateDto budgetCreateDto);
        Task<BudgetResponseDto> GetBudgetByIdAsync(Guid id);
        Task<IEnumerable<BudgetResponseDto>> GetAllBudgetsAsync();
        Task<BudgetResponseDto> UpdateBudgetAsync(Guid id, BudgetUpdateDto budgetUpdateDto);
        Task DeleteBudgetAsync(Guid id);
        Task<IEnumerable<BudgetResponseDto>> GetBudgetsByUserIdAsync(Guid userId);
        Task<IEnumerable<BudgetResponseDto>> GetBudgetsByCategoryIdAsync(Guid categoryId);
        Task<IEnumerable<BudgetResponseDto>> GetBudgetsByMonthAsync(Guid userId, int month, int year);
        Task<IEnumerable<BudgetResponseDto>> GetCurrentMonthBudgetsAsync(Guid userId);
    }
}