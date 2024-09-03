using FitnessCommunity.Domain.Entities;
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
            modelBuilder.Entity<WorkoutExercise>()
                .HasKey(we => new { we.WorkoutId, we.ExerciseId });

            modelBuilder.Entity<WorkoutExercise>()
                .HasOne(we => we.Workout)
                .WithMany(w => w.Exercises)
                .HasForeignKey(we => we.WorkoutId);

            modelBuilder.Entity<WorkoutExercise>()
                .HasOne(we => we.Exercise)
                .WithMany(e => e.Workouts)
                .HasForeignKey(we => we.ExerciseId);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<WorkoutExercise> WorkoutsExercises { get; set; }
    }
}
