using AutoMapper;
using FinanceTracker.Application.DTOs.Account;
using FinanceTracker.Application.Interfaces;
using FinanceTracker.Application.Interfaces.Services;
using FinanceTracker.Domain.Enums;
using FinanceTracker.Domain.Models;

namespace FinanceTracker.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AccountResponseDto> CreateAccountAsync(AccountCreateDto accountCreateDto)
        {
            if (string.IsNullOrEmpty(accountCreateDto.Name))
            {
                throw new ArgumentException("Account name cannot is required");
            }

            var user = await _unitOfWork.Repository<User>().GetByIdAsync(accountCreateDto.UserId);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {accountCreateDto.UserId} not found");
            }

            bool isTaken = await _unitOfWork.AccountRepository.IsAccountNameTakenAsync(accountCreateDto.UserId, accountCreateDto.Name);
            if (isTaken)
            {
                throw new InvalidOperationException($"Account name {accountCreateDto.Name} already exists for this user");
            }

            var account = _mapper.Map<Account>(accountCreateDto);
            await _unitOfWork.AccountRepository.AddAsync(account);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<AccountResponseDto>(account);
        }

        public async Task DeleteAccountAsync(Guid id)
        {
            var account = await _unitOfWork.AccountRepository.GetByIdAsync(id);
            if (account == null)
            {
                throw new KeyNotFoundException($"Account with ID {id} not found");
            }

            _unitOfWork.AccountRepository.Delete(account);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<AccountResponseDto> GetAccountByIdAsync(Guid id)
        {
            var account = await _unitOfWork.AccountRepository.GetByIdAsync(id);
            if (account == null)
            {
                throw new KeyNotFoundException($"Account with ID {id} not found");
            }
            return _mapper.Map<AccountResponseDto>(account);
        }

        public async Task<IEnumerable<AccountResponseDto>> GetAllAccountsAsync()
        {
            var accounts = await _unitOfWork.AccountRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AccountResponseDto>>(accounts);
        }

        public async Task<IEnumerable<AccountResponseDto>> GetAccountsByUserIdAsync(Guid userId)
        {
            var user = await _unitOfWork.AccountRepository.GetByIdAsync(userId);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {userId} not found");
            }

            var accounts = await _unitOfWork.AccountRepository.GetAccountsByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<AccountResponseDto>>(accounts);
        }
        public async Task<AccountResponseDto> UpdateAccountAsync(Guid id, AccountUpdateDto accountUpdateDto)
        {
            var account = await _unitOfWork.AccountRepository.GetByIdAsync(id);
            if (account == null)
            {
                throw new KeyNotFoundException($"Account with ID {id} not found");
            }

            if (!string.IsNullOrWhiteSpace(accountUpdateDto.Name) && accountUpdateDto.Name != account.Name)
            {
                bool isTaken = await _unitOfWork.AccountRepository.IsAccountNameTakenAsync(account.UserId, accountUpdateDto.Name);
                if (isTaken)
                {
                    throw new InvalidOperationException($"Account name {accountUpdateDto.Name} already exists for this user");
                }
            }

            if (!string.IsNullOrWhiteSpace(accountUpdateDto.Name))
                account.Name = accountUpdateDto.Name.Trim();

            if (accountUpdateDto.Type.HasValue)
                account.Type = accountUpdateDto.Type.Value;

            account.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.AccountRepository.Update(account);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<AccountResponseDto>(account);
        }

        public async Task<IEnumerable<AccountResponseDto>> GetAccountsByTypeAsync(AccountType type)
        {
            var accounts = await _unitOfWork.AccountRepository.GetAccountsByTypeAsync(type);
            return _mapper.Map<IEnumerable<AccountResponseDto>>(accounts);
        }
    }
}