using FitnessCommunity.Domain.Abstractions;
using FitnessCommunity.Domain.Entities;

namespace FitnessCommunity.Infrastructure.Database.Repositories
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly FitnessCommunityDbContext dbContext;
        public WorkoutRepository(FitnessCommunityDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public async Task Add(Workout workout)
        {
            await dbContext.AddAsync(workout).ConfigureAwait(true);
        }

        public void Delete(Workout workout)
        {
            dbContext.Remove(workout);
        }

        public async Task<Workout?> GetById(Guid id)
        {
            return await dbContext.Workouts.FindAsync(id).ConfigureAwait(true);
        }


        public void Update(Workout workout)
        {
            dbContext.Update(workout);
        }
    }
}
