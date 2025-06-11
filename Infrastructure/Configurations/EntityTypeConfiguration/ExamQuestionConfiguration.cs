using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.EntityTypeConfiguration
{
    public class ExamQuestionConfiguration : IEntityTypeConfiguration<ExamQuestion>
    {
        public void Configure(EntityTypeBuilder<ExamQuestion> builder)
        {
            
            builder.ToTable("ExamQuestions");

            
            builder.HasKey(q => q.Id);

            builder.Property(q => q.Id)
                .ValueGeneratedOnAdd();

           
            builder.Property(q => q.ExamId)
                .IsRequired();

            builder.Property(q => q.QuestionText)
                .IsRequired()
                .HasMaxLength(1000);  

            builder.Property(q => q.Marks)
                .IsRequired();

            
            builder.HasOne(q => q.Exam)
                .WithMany(e => e.Questions)  
                .HasForeignKey(q => q.ExamId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(q => q.Options)
                .WithOne(o => o.ExamQuestion)
                .HasForeignKey(o => o.ExamQuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(q => q.Answers)
                .WithOne(a => a.ExamQuestion)
                .HasForeignKey(a => a.ExamQuestionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
