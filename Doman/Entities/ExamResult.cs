using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ExamResult
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid ExamId { get; set; }
        public int TotalScore { get; set; }
        public string Grade { get; set; } = default!;
        public DateTime SubmittedAt { get; set; }
        public bool IsReviewed { get; set; }
        public Student Student { get; set; } = default!;
        public Exam Exam { get; set; } = default!;
    }

}
