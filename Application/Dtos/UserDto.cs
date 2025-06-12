using Domain.Enums;

namespace Application.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public Role Role { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
    public class LoginDto
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }   
}
