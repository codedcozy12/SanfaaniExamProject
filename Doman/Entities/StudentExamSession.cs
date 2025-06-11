using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class StudentExamSession
    {
        public Guid Id { get; private set; }
        public Guid StudentId { get; set; }
        public Guid ExamId { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime? SubmittedAt { get; set; }  
        public bool IsCompleted { get; set; }
        public Student Student { get; set; } = default!;
        public Exam Exam { get; set; } = default!;
    }

}
