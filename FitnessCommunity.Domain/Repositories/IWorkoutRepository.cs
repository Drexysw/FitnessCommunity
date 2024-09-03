using FitnessCommunity.Domain.Entities;

namespace FitnessCommunity.Domain.Repositories
{
    public interface IWorkoutRepository
    {
        public Task<IEnumerable<Workout>> GetAllAsync();
        public Task AddAsync(Workout workout);
        public void Delete(Workout workout);
        public Task<Workout> GetByIdAsync(Guid id);
        public void Update(Workout workout);
    }
}
