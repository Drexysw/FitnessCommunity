using FitnessCommunity.Domain.Entities;

namespace FitnessCommunity.Domain.Repositories
{
    public interface IExerciseRepository
    {
        Task<IEnumerable<Exercise>> GetAllAsync();
        Task<Exercise> GetByIdAsync(Guid id);
        Task CreateAsync(Exercise exercise);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(Exercise exercise);
    }
}
