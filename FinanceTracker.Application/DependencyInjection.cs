using FinanceTracker.Application.Mapping;
using FinanceTracker.Application.Validators.Account;
using FinanceTracker.Application.Validators.Budget;
using FinanceTracker.Application.Validators.Category;
using FinanceTracker.Application.Validators.Transaction;
using FinanceTracker.Application.Validators.User;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceTracker.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<AccountCreateDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<BudgetCreateDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<CategoryCreateDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<TransactionCreateDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<UserCreateDtoValidator>();

            return services;
        }
    }
}