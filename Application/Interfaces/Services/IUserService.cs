using Application.Dtos;

namespace Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<ResponseDto<UserDto>> LoginAsync(LoginDto loginDto);
        Task<ResponseDto<bool>> DeactivateUserAsync(Guid id);
        Task<ResponseDto<UserDto>> GetUserByIdAsync(Guid id);
        Task<ResponseDto<IEnumerable<UserDto>>> GetAllUsersAsync();
        Task<ResponseDto<IEnumerable<UserDto>>> SearchUsersAsync(string keyword);
    }
}
