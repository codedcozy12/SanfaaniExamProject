using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
