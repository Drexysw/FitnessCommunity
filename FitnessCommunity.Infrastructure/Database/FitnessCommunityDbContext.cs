using FitnessCommunity.Domain.Entities;
using FitnessCommunity.Infrastructure.Database.Configuration;
using Microsoft.EntityFrameworkCore;

namespace FitnessCommunity.Infrastructure.Database
{
    public class FitnessCommunityDbContext : DbContext
    {
        public FitnessCommunityDbContext()
        {
            
        }
        public FitnessCommunityDbContext(DbContextOptions<FitnessCommunityDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new WorkoutConfiguration());
            modelBuilder.ApplyConfiguration(new UserWorkoutConfiguration());
            modelBuilder.ApplyConfiguration(new BadgeConfiguration());
            modelBuilder.ApplyConfiguration(new UserBadgeConfiguration());
            modelBuilder.ApplyConfiguration(new ExerciseConfiguration());
            modelBuilder.ApplyConfiguration(new WorkoutExerciseConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<WorkoutExercise> WorkoutsExercises { get; set; }
        public DbSet<Badge?> Badges { get; set; }
        public DbSet<UserWorkout> UsersWorkouts { get; set; }
        public DbSet<UserBadge> UsersBadges { get; set; }
    }
}
