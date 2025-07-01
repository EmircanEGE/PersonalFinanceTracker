using System.Data;
using FinanceTracker.Application.DTOs.Budget;
using FluentValidation;

namespace FinanceTracker.Application.Validators.Budget
{
    public class BudgetCreateDtoValidator : AbstractValidator<BudgetCreateDto>
    {
        public BudgetCreateDtoValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("User ID is required.");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Category ID is required.");
            RuleFor(x => x.Month).NotEmpty().InclusiveBetween(1, 12);
            RuleFor(x => x.Year).NotEmpty().InclusiveBetween(2000, 2100);
            RuleFor(x => x.Limit).NotEmpty().GreaterThan(0);
        }
    }
}