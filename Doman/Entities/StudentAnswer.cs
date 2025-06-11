using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class StudentAnswer
    {
        public Guid Id { get; private set; }
        public Guid StudentId { get; set; }
        public Guid ExamQuestionId { get; set; }
        public Guid SelectedOptionId { get; set; }
        public DateTime SubmittedAt { get; set; }
        public Student Student { get; set; } = default!;
        public ExamQuestion ExamQuestion { get; set; } = default!;
        public QuestionOption SelectedOption { get; set; } = default!;
    }


}
