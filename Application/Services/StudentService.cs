using Application.Dtos;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Interfaces.UnitOfWork;
using Domain.Entities;
using Domain.Enums;

namespace Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUserRepository _userRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IUnitOfWork _unitOfWork;
        public StudentService(IUserRepository userRepository, IStudentRepository studentRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseDto<StudentResponseDto>> CreateStudentAsync(StudentCreateDto dto)
        {
            var existingUserByUsername = await _userRepository.GetByEmailAsync(dto.Username);
            if (existingUserByUsername != null)
                return ResponseDto<StudentResponseDto>.Fail("Username already exists.");

            var existingUserByEmail = await _userRepository.GetByEmailAsync(dto.Email);
            if (existingUserByEmail != null)
                return ResponseDto<StudentResponseDto>.Fail("Email is already in use.");

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);
            var userId = Guid.NewGuid();

            var user = new User
            {
                Id = userId,
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = hashedPassword,
                Role = Role.Student,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            var student = new Student
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Religion = dto.Religion,
                PhoneNumber = dto.PhoneNumber,
                SchoolName = dto.SchoolName,
                Address = dto.Address,
                GradeLevel = dto.GradeLevel,
                DateOfBirth = dto.DateOfBirth,
                CreatedAt = DateTime.UtcNow
            };

            await _userRepository.AddAsync(user);
            await _studentRepository.AddAsync(student);
            await _unitOfWork.SaveChangesAsync();

            var response = new StudentResponseDto
            {
                Id = student.Id,
                FullName = student.FullName,
                Email = student.Email,
                PhoneNumber = student.PhoneNumber,
                SchoolName = student.SchoolName,
                Address = student.Address,
                GradeLevel = student.GradeLevel,
                Religion = student.Religion.ToString(),
                DateOfBirth = student.DateOfBirth,
                CreatedAt = student.CreatedAt
            };

            return ResponseDto<StudentResponseDto>.Success(response, "Student created successfully.");
        }

        public async Task<ResponseDto<StudentResponseDto>> GetStudentByIdAsync(Guid id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null)
                return ResponseDto<StudentResponseDto>.Fail("Student not found.");

            var response = new StudentResponseDto
            {
                Id = student.Id,
                FullName = student.FullName,
                Email = student.Email,
                PhoneNumber = student.PhoneNumber,
                SchoolName = student.SchoolName,
                Address = student.Address,
                GradeLevel = student.GradeLevel,
                Religion = student.Religion.ToString(),
                DateOfBirth = student.DateOfBirth,
                CreatedAt = student.CreatedAt
            };

            return ResponseDto<StudentResponseDto>.Success(response, "Student retrieved successfully.");
        }

        public async Task<ResponseDto<IEnumerable<StudentResponseDto>>> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetAllAsync();

            var result = students.Select(student => new StudentResponseDto
            {
                Id = student.Id,
                FullName = student.FullName,
                Email = student.Email,
                PhoneNumber = student.PhoneNumber,
                SchoolName = student.SchoolName,
                Address = student.Address,
                GradeLevel = student.GradeLevel,
                Religion = student.Religion.ToString(),
                DateOfBirth = student.DateOfBirth,
                CreatedAt = student.CreatedAt
            }).ToList();

            return ResponseDto<IEnumerable<StudentResponseDto>>.Success(result, "Students retrieved successfully.");
        }

        public async Task<ResponseDto<bool>> UpdateStudentAsync(Guid id, StudentUpdateDto dto)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null || !student.IsActive)
                return ResponseDto<bool>.Fail("Student not found.");

            student.FullName = dto.FullName;
            student.Email = dto.Email;
            student.PhoneNumber = dto.PhoneNumber;
            student.SchoolName = dto.SchoolName;
            student.Address = dto.Address;
            student.GradeLevel = dto.GradeLevel;
            student.Religion = dto.Religion;
            student.DateOfBirth = dto.DateOfBirth;

            await _studentRepository.UpdateAsync(student);
            await _unitOfWork.SaveChangesAsync();

            return ResponseDto<bool>.Success(true, "Student updated successfully.");
        }

        public async Task<ResponseDto<bool>> DeleteStudentAsync(Guid id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null || !student.IsActive)
                return ResponseDto<bool>.Fail("Student not found.");

            student.IsActive = false;
            await _studentRepository.UpdateAsync(student);
            await _unitOfWork.SaveChangesAsync();

            return ResponseDto<bool>.Success(true, "Student deleted successfully.");
        }

        public async Task<ResponseDto<IEnumerable<StudentResponseDto>>> SearchStudentsAsync(string keyword)
        {
            var allStudents = await _studentRepository.GetAllAsync();
            var filtered = allStudents
                .Where(s => s.IsActive && (
                    s.FullName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                    s.Email.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                    s.SchoolName.Contains(keyword, StringComparison.OrdinalIgnoreCase)))
                .Select(student => new StudentResponseDto
                {
                    Id = student.Id,
                    FullName = student.FullName,
                    Email = student.Email,
                    PhoneNumber = student.PhoneNumber,
                    SchoolName = student.SchoolName,
                    Address = student.Address,
                    GradeLevel = student.GradeLevel,
                    Religion = student.Religion.ToString(),
                    DateOfBirth = student.DateOfBirth,
                    CreatedAt = student.CreatedAt
                });

            return ResponseDto<IEnumerable<StudentResponseDto>>.Success(filtered.ToList(), "Search results.");
        }


    }
}
