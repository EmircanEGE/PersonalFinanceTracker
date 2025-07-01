using FinanceTracker.Application.DTOs.Category;
using FluentValidation;

namespace FinanceTracker.Application.Validators.Category
{
    public class CategoryCreateDtoValidator : AbstractValidator<CategoryCreateDto>
    {
        public CategoryCreateDtoValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");
            RuleFor(x => x.Type).NotEmpty().WithMessage("Type is required.")
                .IsInEnum().WithMessage("Type must be a valid category type (Income, Expense).");
        }
    }
}