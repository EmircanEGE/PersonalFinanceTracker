using AutoMapper;
using FinanceTracker.Application.DTOs;
using FinanceTracker.Application.DTOs.Account;
using FinanceTracker.Application.DTOs.Budget;
using FinanceTracker.Application.DTOs.Category;
using FinanceTracker.Application.DTOs.Transaction;
using FinanceTracker.Domain.Models;

namespace FinanceTracker.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AccountCreateDto, Account>();
            CreateMap<Account, AccountResponseDto>();

            CreateMap<BudgetCreateDto, Budget>();
            CreateMap<Budget, BudgetResponseDto>();

            CreateMap<CategoryCreateDto, Category>();
            CreateMap<Category, CategoryResponseDto>();

            CreateMap<TransactionCreateDto, Transaction>();
            CreateMap<Transaction, TransactionResponseDto>();

            CreateMap<UserCreateDto, User>();
            CreateMap<User, UserResponseDto>();
        }
    }
}