using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityTypeConfiguration
{
    public class StudentExamSessionConfiguration : IEntityTypeConfiguration<StudentExamSession>
    {
        public void Configure(EntityTypeBuilder<StudentExamSession> builder)
        {
            
            builder.ToTable("StudentExamSessions");

            
            builder.HasKey(s => s.Id);

             
            builder.Property(s => s.Id)
                .ValueGeneratedOnAdd();

            builder.Property(s => s.StudentId)
                .IsRequired();

            builder.Property(s => s.ExamId)
                .IsRequired();

            builder.Property(s => s.StartedAt)
                .IsRequired();

            builder.Property(s => s.IsCompleted)
                .IsRequired();

            
            builder.HasOne(s => s.Student)
                .WithMany(st => st.ExamSessions)  
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.Exam)
                .WithMany(e => e.ExamSessions) 
                .HasForeignKey(s => s.ExamId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
