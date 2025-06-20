﻿using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistense.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistense.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;
        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Student?> GetByIdAsync(Guid id)
        {
            return await _context.Students
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Student?> GetByEmailAsync(string email)
        {
            return await _context.Students
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students
                .ToListAsync();
        }

        public async Task AddAsync(Student student)
        {
            await _context.Students.AddAsync(student);
        }

        public async Task DeleteAsync(Guid id)
        {
            var student = await GetByIdAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _context.Students.AnyAsync(u => u.Id == id);
        }

        public async Task UpdateAsync(Student student)
        {
            _context.Students.Update(student);
        }
    }
}
