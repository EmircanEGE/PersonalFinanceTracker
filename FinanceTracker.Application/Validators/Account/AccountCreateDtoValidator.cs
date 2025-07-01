using FinanceTracker.Application.DTOs.Account;
using FluentValidation;

namespace FinanceTracker.Application.Validators.Account
{
    public class AccountCreateDtoValidator : AbstractValidator<AccountCreateDto>
    {
        public AccountCreateDtoValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("User ID is required.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");
            RuleFor(x => x.Type).NotEmpty().WithMessage("Type is required.")
                .IsInEnum().WithMessage("Type must be a valid account type (Cash, CreditCard, Bank).");
        }
    }
}