using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class QuestionOption
    {
        public Guid Id { get; set; }
        public Guid ExamQuestionId { get; set; }
        public string Text { get; set; } = default!;
        public bool IsCorrect { get; set; }
        public ExamQuestion ExamQuestion { get; set; } = default!;
    }

}
