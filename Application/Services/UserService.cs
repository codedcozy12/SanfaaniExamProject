using Application.Dtos;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Interfaces.UnitOfWork;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseDto<UserDto>> LoginAsync(LoginDto loginDto)
        {
            var user = await _userRepository.GetByUserNameAsync(loginDto.Username);
            if (user is null || !user.IsActive)
                return ResponseDto<UserDto>.Fail("Invalid Username or account is inactive.");

            if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
                return ResponseDto<UserDto>.Fail("Invalid password.");

            return ResponseDto<UserDto>.Success(new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role,
                IsActive = user.IsActive,
                CreatedAt = user.CreatedAt
            }, "Login successful.");
        }

        public async Task<ResponseDto<UserDto>> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user is null || !user.IsActive)
                return ResponseDto<UserDto>.Fail("User not found.");

            return ResponseDto<UserDto>.Success(new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role,
                IsActive = user.IsActive,
                CreatedAt = user.CreatedAt
            }, "User retrieved.");
        }

        public async Task<ResponseDto<IEnumerable<UserDto>>> GetAllUsersAsync()
        {
            var users = (await _userRepository.GetAllAsync())
                .Where(u => u.IsActive)
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Username = u.Username,
                    Email = u.Email,
                    Role = u.Role,
                    IsActive = u.IsActive,
                    CreatedAt = u.CreatedAt
                });

            return ResponseDto<IEnumerable<UserDto>>.Success(users.ToList(), "Active users retrieved.");
        }

        public async Task<ResponseDto<IEnumerable<UserDto>>> SearchUsersAsync(string keyword)
        {
            var users = (await _userRepository.GetAllAsync())
                .Where(u => u.IsActive &&
                            (u.Username.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                             u.Email.Contains(keyword, StringComparison.OrdinalIgnoreCase)))
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Username = u.Username,
                    Email = u.Email,
                    Role = u.Role,
                    IsActive = u.IsActive,
                    CreatedAt = u.CreatedAt
                });

            return ResponseDto<IEnumerable<UserDto>>.Success(users.ToList(), "Users matched your search.");
        }

        public async Task<ResponseDto<bool>> DeactivateUserAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user is null || !user.IsActive)
                return ResponseDto<bool>.Fail("User not found or already inactive.");

            user.IsActive = false;
            await _userRepository.UpdateAsync(user);
            await _unitOfWork.SaveChangesAsync();

            return ResponseDto<bool>.Success(true, "User deactivated successfully.");
        }
    }

}
