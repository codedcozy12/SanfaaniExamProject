using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
