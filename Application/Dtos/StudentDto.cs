using Domain.Enums;
using System.ComponentModel.DataAnnotations;
namespace Application.Dtos
{
    public class StudentCreateDto
    {
        [Required]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Username can only contain letters, numbers, and underscores.")]
        public string Username { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(6)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d).{6,}$",
    ErrorMessage = "Password must be at least 6 characters long and contain both letters and numbers.")]

        public string Password { get; set; } = string.Empty;
 

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public Religion Religion { get; set; }

        [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Invalid phone number.")]
        public required string PhoneNumber { get; set; }

        [Required]
        [MaxLength(100)]
        public string SchoolName { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Address { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string GradeLevel { get; set; } = string.Empty;

        [Required]
        public DateOnly DateOfBirth { get; set; }
    }
    public class StudentResponseDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string SchoolName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string GradeLevel { get; set; } = string.Empty;
        public string Religion { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; }
    }
    

    public class StudentUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Invalid phone number.")]
        public string? PhoneNumber { get; set; }

        [Required]
        public Religion Religion { get; set; }

        [Required]
        [MaxLength(100)]
        public string SchoolName { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Address { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string GradeLevel { get; set; } = string.Empty;

        [Required]
        public DateOnly DateOfBirth { get; set; }
    }

}
