using FinanceTracker.Application.DTOs;

namespace FinanceTracker.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserResponseDto> CreateUserAsync(UserCreateDto userCreateDto);
        Task<UserResponseDto> GetUserByIdAsync(Guid id);
        Task<IEnumerable<UserResponseDto>> GetAllUsersAsync();
    }
}