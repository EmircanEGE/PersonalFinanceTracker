using FinanceTracker.Domain.Enums;

namespace FinanceTracker.Application.DTOs.Category
{
    public class CategoryCreateDto
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public CategoryType Type { get; set; }
    }
}