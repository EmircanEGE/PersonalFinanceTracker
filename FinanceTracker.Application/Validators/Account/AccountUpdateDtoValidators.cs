using FinanceTracker.Application.DTOs.Account;
using FluentValidation;

namespace FinanceTracker.Application.Validators.Account
{
    public class AccountUpdateDtoValidators : AbstractValidator<AccountUpdateDto>
    {
        public AccountUpdateDtoValidators()
        {
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("Name must not exceed 100 characters.");
            RuleFor(x => x.Type).IsInEnum().WithMessage("Type must be a valid account type (Cash, CreditCard, Bank).");
        }
    }
}