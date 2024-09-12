using FitnessCommunity.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitnessCommunity.Infrastructure.Database
{
    public sealed class FitnessCommunityDbContext : DbContext
    {
        public FitnessCommunityDbContext(DbContextOptions<FitnessCommunityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FitnessCommunityDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<WorkoutExercise> WorkoutsExercises { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<UserWorkout> UsersWorkouts { get; set; }
        public DbSet<UserBadge> UsersBadges { get; set; }
    }
}