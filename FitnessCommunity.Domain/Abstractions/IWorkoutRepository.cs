using FitnessCommunity.Domain.Entities;

namespace FitnessCommunity.Domain.Abstractions
{
    public interface IWorkoutRepository
    {
        public Task Add(Workout workout);
        public void Delete(Workout workout);
        public Task<Workout> GetById(Guid id);
        public void Update(Workout workout);
    }
}
