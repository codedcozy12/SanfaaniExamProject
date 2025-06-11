using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityTypeConfiguration
{
    

    public class StudentAnswerConfiguration : IEntityTypeConfiguration<StudentAnswer>
    {
        public void Configure(EntityTypeBuilder<StudentAnswer> builder)
        { 

            builder.ToTable("StudentAnswers");

            
            builder.HasKey(sa => sa.Id);

            
            builder.Property(sa => sa.Id)
                .ValueGeneratedOnAdd();

            builder.Property(sa => sa.StudentId)
                .IsRequired();

            builder.Property(sa => sa.ExamQuestionId)
                .IsRequired();

            builder.Property(sa => sa.SelectedOptionId)
                .IsRequired();

            builder.Property(sa => sa.SubmittedAt)
                .IsRequired();

             
            builder.HasOne(sa => sa.Student)
                .WithMany(s => s.Answers)  
                .HasForeignKey(sa => sa.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

           
            builder.HasOne(sa => sa.ExamQuestion)
                .WithMany(eq => eq.Answers) 
                .HasForeignKey(sa => sa.ExamQuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            
            builder.HasOne(sa => sa.SelectedOption)
                .WithMany()
                .HasForeignKey(sa => sa.SelectedOptionId)
                .OnDelete(DeleteBehavior.Restrict);  
        }
    }

}
