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
