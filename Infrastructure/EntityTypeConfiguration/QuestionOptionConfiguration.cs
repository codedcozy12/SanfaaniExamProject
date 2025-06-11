using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.EntityTypeConfiguration
{
   
    public class QuestionOptionConfiguration : IEntityTypeConfiguration<QuestionOption>
    {
        public void Configure(EntityTypeBuilder<QuestionOption> builder)
        {
            
            builder.ToTable("QuestionOptions");

             
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
                .ValueGeneratedOnAdd();

            builder.Property(o => o.ExamQuestionId)
                .IsRequired();

            builder.Property(o => o.Text)
                .IsRequired()
                .HasMaxLength(500);  

            builder.Property(o => o.IsCorrect)
                .IsRequired();

            
            builder.HasOne(o => o.ExamQuestion)
                .WithMany(q => q.Options)  
                .HasForeignKey(o => o.ExamQuestionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
