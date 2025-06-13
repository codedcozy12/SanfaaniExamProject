using Application.Dtos;

namespace Application.Interfaces.Services
{
    public interface IStudentService
    {
        Task<ResponseDto<StudentResponseDto>> CreateStudentAsync(StudentCreateDto dto);
        Task<ResponseDto<StudentResponseDto>> GetStudentByIdAsync(Guid id);
        Task<ResponseDto<IEnumerable<StudentResponseDto>>> GetAllStudentsAsync();
        Task<ResponseDto<bool>> UpdateStudentAsync(Guid id, StudentUpdateDto dto);
        Task<ResponseDto<bool>> DeleteStudentAsync(Guid id);
        Task<ResponseDto<IEnumerable<StudentResponseDto>>> SearchStudentsAsync(string keyword);
    }

}
