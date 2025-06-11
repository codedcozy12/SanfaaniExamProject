using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityTypeConfiguration
{
    

    public class ExamResultConfiguration : IEntityTypeConfiguration<ExamResult>
    {
        public void Configure(EntityTypeBuilder<ExamResult> builder)
        {
             
            builder.ToTable("ExamResults");
             
             
            builder.HasKey(er => er.Id);

            builder.Property(er => er.Id)
                .ValueGeneratedOnAdd();

            
            builder.Property(er => er.StudentId)
                .IsRequired();

            builder.Property(er => er.ExamId)
                .IsRequired();

            builder.Property(er => er.TotalScore)
                .IsRequired();

            builder.Property(er => er.Grade)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(er => er.SubmittedAt)
                .IsRequired();

            builder.Property(er => er.IsReviewed)
                .IsRequired();

            

            builder.HasOne(er => er.Student)
                .WithMany(s => s.Results)
                .HasForeignKey(er => er.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(er => er.Exam)
                .WithMany(e => e.Results)
                .HasForeignKey(er => er.ExamId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
