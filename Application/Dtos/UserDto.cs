using Domain.Enums;

namespace Application.Dtos
{
    public class UserDto
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public required string Username { get; set; }
        public required string Email { get; set; }
        public Role Role { get; set; }
    }
}
