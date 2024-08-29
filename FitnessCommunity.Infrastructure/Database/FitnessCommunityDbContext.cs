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
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
    }
}
