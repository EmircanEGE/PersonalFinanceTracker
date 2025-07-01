using System.Data;
using FinanceTracker.Application.DTOs.Transaction;
using FluentValidation;

namespace FinanceTracker.Application.Validators.Transaction
{
    public class TransactionCreateDtoValidator : AbstractValidator<TransactionCreateDto>
    {
        public TransactionCreateDtoValidator()
        {
            RuleFor(x => x.AccountId).NotEmpty().WithMessage("User ID is required.");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Category ID is required.");
            RuleFor(x => x.Amount).NotEmpty().WithMessage("Amount is required.")
                .GreaterThan(0).WithMessage("Amount must be greater than zero.");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Date is required.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required.")
                .MaximumLength(200).WithMessage("Description must not exceed 200 characters.");
            RuleFor(x => x.Type).NotEmpty().WithMessage("Type is required.")
                .IsInEnum().WithMessage("Type must be a valid transaction type (Income, Expense, Transfer).");
        }
    }
}