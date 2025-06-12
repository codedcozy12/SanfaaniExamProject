using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.EntityTypeConfiguration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
             
            builder.ToTable("Students");

            
            builder.HasKey(s => s.Id);

            
            builder.Property(s => s.Id)
                .ValueGeneratedOnAdd();

            builder.Property(s => s.FullName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(s => s.Email)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(s => s.Religion)
                .IsRequired();

            builder.Property(s => s.PhoneNumber)
                .HasMaxLength(20);

            builder.Property(s => s.SchoolName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(s => s.Address)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(s => s.GradeLevel)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.DateOfBirth)
                .HasConversion(v => v.ToDateTime(TimeOnly.MinValue), v => DateOnly.FromDateTime(v))
                .HasColumnType("date")
                .IsRequired();

            builder.Property(s => s.CreatedAt);

            
            builder.HasMany(s => s.Answers)
                .WithOne(a => a.Student)
                .HasForeignKey(a => a.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
 
            builder.HasMany(s => s.Results)
                .WithOne(r => r.Student)
                .HasForeignKey(r => r.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            
            builder.HasMany(s => s.ExamSessions)
                .WithOne(es => es.Student)
                .HasForeignKey(es => es.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
