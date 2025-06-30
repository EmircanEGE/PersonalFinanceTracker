using FinanceTracker.Application.DTOs;
using FinanceTracker.Application.Interfaces;
using FinanceTracker.Application.Interfaces.Services;

namespace FinanceTracker.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<UserResponseDto> CreateUserAsync(UserCreateDto userCreateDto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserResponseDto>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserResponseDto> GetUserByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}