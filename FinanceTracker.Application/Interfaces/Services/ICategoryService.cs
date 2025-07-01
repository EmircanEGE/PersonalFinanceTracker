using FinanceTracker.Application.DTOs.Category;

namespace FinanceTracker.Application.Interfaces.Services
{
    public interface ICategoryService
    {
        Task CreateCategoryAsync(CategoryCreateDto categoryCreateDto);
        Task<CategoryResponseDto> GetCategoryByIdAsync(Guid id);
        Task<IEnumerable<CategoryResponseDto>> GetAllCategoriesAsync();
    }
}