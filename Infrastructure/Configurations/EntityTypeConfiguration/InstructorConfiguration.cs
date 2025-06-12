using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.EntityTypeConfiguration
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        { 
            
            builder.ToTable("Instructors");

            
            builder.HasKey(i => i.Id);

             
            builder.Property(i => i.Id)
                .ValueGeneratedOnAdd();

            builder.Property(i => i.FullName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(i => i.Email)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(i => i.IsActive)
                .IsRequired();

            builder.Property(i => i.CreatedAt)
                .IsRequired();

           
            builder.HasMany(i => i.Exams)
                .WithOne(e => e.Instructor)
                .HasForeignKey(e => e.InstructorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
