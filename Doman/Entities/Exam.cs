using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Exam
    {
        private int _durationMinutes;
        private DateTime _startTime;

        public Guid Id { get; private set; }
        public string Title { get; set; } = default!;
        public Guid InstructorId { get; set; }

        public DateTime StartTime
        {
            get => _startTime;
            set
            {
                _startTime = value;
                EndTime = _startTime.AddMinutes(DurationMinutes);
            }
        }

        public int DurationMinutes
        {
            get => _durationMinutes;
            set
            {
                _durationMinutes = value;
                EndTime = StartTime.AddMinutes(_durationMinutes);
            }
        }

        public DateTime EndTime { get; private set; }

        public int TotalMarks { get; set; }
        public bool IsPublished { get; set; }
        public Instructor Instructor { get; set; } = default!;
        public ICollection<ExamQuestion> Questions { get; set; } = new HashSet<ExamQuestion>();
        public ICollection<ExamResult> Results { get; set; } = new HashSet<ExamResult>();
        public ICollection<StudentExamSession> ExamSessions { get; set; } = new HashSet<StudentExamSession>();
    }


}
