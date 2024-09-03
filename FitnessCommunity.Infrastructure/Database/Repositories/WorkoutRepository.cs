using FitnessCommunity.Domain.Entities;
using FitnessCommunity.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FitnessCommunity.Infrastructure.Database.Repositories
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly FitnessCommunityDbContext dbContext;
        public WorkoutRepository(FitnessCommunityDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<IEnumerable<Workout>> GetAllAsync()
        {
            return await dbContext.Workouts.ToListAsync().ConfigureAwait(true);
        }

        public async Task AddAsync(Workout workout)
        {
            await dbContext.AddAsync(workout).ConfigureAwait(true);
        }

        public void Delete(Workout workout)
        {
            dbContext.Remove(workout);
        }

        public async Task<Workout?> GetByIdAsync(Guid id)
        {
            return await dbContext.Workouts.FindAsync(id).ConfigureAwait(true);
        }


        public void Update(Workout workout)
        {
            dbContext.Update(workout);
        }
    }
}
