using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IStudentRepository
    {
        Task<Student?> GetByIdAsync(Guid id);
        Task<Student?> GetByEmailAsync(string email);
        Task<IEnumerable<Student>> GetAllAsync();
        Task AddAsync(Student student);
        void Update(Student student);
        Task DeleteAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
    }
}
