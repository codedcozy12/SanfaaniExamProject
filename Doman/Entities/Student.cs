﻿using Domain.Enums;

namespace Domain.Entities
{
    public class Student
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public Religion Religion { get; set; }
        public string? PhoneNumber { get; set; }
        public string SchoolName { get; set; } = default!;  
        public string Address { get; set; } = default!;
        public string GradeLevel { get; set; } = default!;
        public bool IsActive { get; set; } = true;
        public DateOnly DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<StudentAnswer> Answers { get; set; } = new HashSet<StudentAnswer>();
        public ICollection<ExamResult> Results { get; set; } = new HashSet<ExamResult>();
        public ICollection<StudentExamSession> ExamSessions { get; set; } = new HashSet<StudentExamSession>();

    }
}
