using FinanceTracker.Application.DTOs;

namespace FinanceTracker.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task CreateUserAsync(UserCreateDto userCreateDto);
        Task<UserResponseDto> GetUserByIdAsync(Guid id);
        Task<UserResponseDto> GetByEmailAsync(string email);
        Task<bool> IsEmailTakenAsync(string email);
        Task<IEnumerable<UserResponseDto>> GetAllUsersAsync();
    }
}