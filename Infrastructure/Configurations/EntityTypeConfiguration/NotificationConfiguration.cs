using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.EntityTypeConfiguration
{
    

    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
             
            builder.ToTable("Notifications");

            
            builder.HasKey(n => n.Id);

            
            builder.Property(n => n.Id)
                .ValueGeneratedOnAdd();

            builder.Property(n => n.UserId)
                .IsRequired();

            builder.Property(n => n.Message)
                .IsRequired()
                .HasMaxLength(1000);  

            builder.Property(n => n.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(n => n.IsRead)
                .IsRequired();

            
            builder.HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
