using FitnessCommunity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessCommunity.Infrastructure.Database.Configuration
{
    public class UserWorkoutConfiguration : IEntityTypeConfiguration<UserWorkout>
    {
        public void Configure(EntityTypeBuilder<UserWorkout> builder)
        {
            builder.HasKey(uw => new { uw.UserId, uw.WorkoutId });

            // Configure relationship with User
            builder.HasOne(uw => uw.User)
                .WithMany(u => u.LikedWorkouts)
                .HasForeignKey(uw => uw.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(uw => uw.Workout)
                .WithMany(w => w.LikedByUsers)
                .HasForeignKey(uw => uw.WorkoutId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
