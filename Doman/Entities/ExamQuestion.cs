namespace Domain.Entities
{
    public class ExamQuestion
    {
        public Guid Id { get; set; }
        public Guid ExamId { get; set; }
        public string QuestionText { get; set; } = default!;
        public int Marks { get; set; }
        public Exam Exam { get; set; } = default!;
        public ICollection<StudentAnswer> Answers { get; set; } = new HashSet<StudentAnswer>();
        public ICollection<QuestionOption> Options { get; set; } = new HashSet<QuestionOption>();
    }

}
