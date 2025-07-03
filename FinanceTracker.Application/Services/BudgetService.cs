using AutoMapper;
using FinanceTracker.Application.DTOs.Budget;
using FinanceTracker.Application.Interfaces;
using FinanceTracker.Application.Interfaces.Services;
using FinanceTracker.Domain.Models;

namespace FinanceTracker.Application.Services;

public class BudgetService : IBudgetService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BudgetService(IUnitOfWork unitOfWork, IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }

    public async Task<BudgetResponseDto> CreateBudgetAsync(BudgetCreateDto budgetCreateDto)
    {
        var category = await _unitOfWork.Repository<Category>().GetByIdAsync(budgetCreateDto.CategoryId);
        if (category == null)
        {
            throw new KeyNotFoundException($"Category with ID {budgetCreateDto.CategoryId} not found");
        }

        var user = await _unitOfWork.Repository<User>().GetByIdAsync(budgetCreateDto.UserId);
        if (user == null)
        {
            throw new KeyNotFoundException($"User with ID {budgetCreateDto.UserId} not found");
        }
        
        if(budgetCreateDto.Month < 1 || budgetCreateDto.Month > 12)
        {
            throw new ArgumentException("Month must be between 1 and 12");
        }
        if(budgetCreateDto.Year < 2000 || budgetCreateDto.Year > 2100)
        {
            throw new ArgumentException("Year must be a valid year");
        }
        if (budgetCreateDto.Limit <= 0)
        {
            throw new ArgumentException("Budget limit must be greater than zero");
        }

        var budget = _mapper.Map<Budget>(budgetCreateDto);
        await _unitOfWork.Repository<Budget>().AddAsync(budget);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<BudgetResponseDto>(budget);
    }

    public async Task<BudgetResponseDto> GetBudgetByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Budget ID cannot be empty", nameof(id));
        }
        var budget = await _unitOfWork.Repository<Budget>().GetByIdAsync(id);
        if (budget == null)
        {
            throw new KeyNotFoundException($"Budget with ID {id} not found");
        }

        return _mapper.Map<BudgetResponseDto>(budget);
    }

    public async Task<IEnumerable<BudgetResponseDto>> GetAllBudgetsAsync()
    {
        var budgets = await _unitOfWork.Repository<Budget>().GetAllAsync();
        return _mapper.Map<IEnumerable<BudgetResponseDto>>(budgets);
    }

    public async Task<BudgetResponseDto> UpdateBudgetAsync(Guid id, BudgetUpdateDto budgetUpdateDto)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Budget ID cannot be empty", nameof(id));
        }

        var budget = await _unitOfWork.Repository<Budget>().GetByIdAsync(id);
        if (budget == null)
        {
            throw new KeyNotFoundException($"Budget with ID {id} not found");
        }

        if (budgetUpdateDto.Limit.HasValue)
        {
            if (budgetUpdateDto.Limit <= 0)
            {
                throw new ArgumentException("Budget limit must be greater than zero", nameof(budgetUpdateDto.Limit));
            }
            budget.Limit = budgetUpdateDto.Limit.Value;
        }

        if (budgetUpdateDto.UserId.HasValue && budgetUpdateDto.UserId != Guid.Empty)
        {
            var user = await _unitOfWork.Repository<User>().GetByIdAsync(budgetUpdateDto.UserId.Value);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {budgetUpdateDto.UserId} not found");
            }
            budget.UserId = budgetUpdateDto.UserId.Value;
        }

        if (budgetUpdateDto.CategoryId.HasValue && budgetUpdateDto.CategoryId != Guid.Empty)
        {
            var category = await _unitOfWork.Repository<Category>().GetByIdAsync(budgetUpdateDto.CategoryId.Value);
            if (category == null)
            {
                throw new KeyNotFoundException($"Category with ID {budgetUpdateDto.CategoryId} not found");
            }
            budget.CategoryId = budgetUpdateDto.CategoryId.Value;
        }

        if (budgetUpdateDto.Month.HasValue)
        {
            if (budgetUpdateDto.Month < 1 || budgetUpdateDto.Month > 12)
            {
                throw new ArgumentException("Month must be between 1 and 12", nameof(budgetUpdateDto.Month));
            }
            budget.Month = budgetUpdateDto.Month.Value;
        }

        if (budgetUpdateDto.Year.Value > 0)
        {
            if (budgetUpdateDto.Year < 2000 || budgetUpdateDto.Year > 2100)
            {
                throw new ArgumentException("Year must be a valid year", nameof(budgetUpdateDto.Year));
            }
            budget.Year = budgetUpdateDto.Year.Value;
        }

        budget.UpdatedAt = DateTime.UtcNow;

        _unitOfWork.Repository<Budget>().Update(budget);
        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<BudgetResponseDto>(budget);
    }

    public async Task DeleteBudgetAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Budget ID cannot be empty", nameof(id));
        }

        var budget = await _unitOfWork.Repository<Budget>().GetByIdAsync(id);
        if (budget == null)
        {
            throw new KeyNotFoundException($"Budget with ID {id} not found");
        }

        _unitOfWork.Repository<Budget>().Delete(budget);
        await _unitOfWork.SaveChangesAsync();
    }

    public Task<IEnumerable<BudgetResponseDto>> GetBudgetsByUserIdAsync(Guid userId)
    {
        if (userId == Guid.Empty)
        {
            throw new ArgumentException("User ID cannot be empty", nameof(userId));
        }

        var budgets = _unitOfWork.Repository<Budget>().FindAsync(b => b.UserId == userId);
        return Task.FromResult(_mapper.Map<IEnumerable<BudgetResponseDto>>(budgets));
    }

    public Task<IEnumerable<BudgetResponseDto>> GetBudgetsByCategoryIdAsync(Guid categoryId)
    {
        if (categoryId == Guid.Empty)
        {
            throw new ArgumentException("Category ID cannot be empty", nameof(categoryId));
        }

        var budgets = _unitOfWork.Repository<Budget>().FindAsync(b => b.CategoryId == categoryId);
        return Task.FromResult(_mapper.Map<IEnumerable<BudgetResponseDto>>(budgets));
    }

    public Task<IEnumerable<BudgetResponseDto>> GetBudgetsByMonthAsync(Guid userId, int month, int year)
    {
        if (userId == Guid.Empty)
        {
            throw new ArgumentException("User ID cannot be empty", nameof(userId));
        }

        if (month < 1 || month > 12)
        {
            throw new ArgumentException("Month must be between 1 and 12", nameof(month));
        }

        if (year < 2000 || year > 2100)
        {
            throw new ArgumentException("Year must be a valid year", nameof(year));
        }

        var budgets = _unitOfWork.Repository<Budget>().FindAsync(b => b.UserId == userId && b.Month == month && b.Year == year);
        return Task.FromResult(_mapper.Map<IEnumerable<BudgetResponseDto>>(budgets));
    }

    public Task<IEnumerable<BudgetResponseDto>> GetCurrentMonthBudgetsAsync(Guid userId)
    {
        if (userId == Guid.Empty)
        {
            throw new ArgumentException("User ID cannot be empty", nameof(userId));
        }

        var currentMonth = DateTime.UtcNow.Month;
        var currentYear = DateTime.UtcNow.Year;

        var budgets = _unitOfWork.Repository<Budget>().FindAsync(b => b.UserId == userId && b.Month == currentMonth && b.Year == currentYear);
        return Task.FromResult(_mapper.Map<IEnumerable<BudgetResponseDto>>(budgets));
    }
}