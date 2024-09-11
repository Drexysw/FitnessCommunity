using FitnessCommunity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessCommunity.Infrastructure.Database.Configuration
{
    public class WorkoutConfiguration : IEntityTypeConfiguration<Workout>
    {
        public void Configure(EntityTypeBuilder<Workout> builder)
        {
            builder.HasKey(w => w.Id);
            builder.Property(w => w.Name).IsRequired().HasMaxLength(70);
            builder.Property(w => w.Description).HasMaxLength(500);
            builder.Property(w => w.Level).IsRequired();
            builder.Property(w => w.Type).IsRequired();

            builder.HasMany(w => w.WorkoutExercises)
                .WithOne(we => we.Workout)
                .HasForeignKey(we => we.WorkoutId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(w => w.LikedByUsers)
                .WithOne(wu => wu.Workout)
                .HasForeignKey(wu => wu.WorkoutId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
