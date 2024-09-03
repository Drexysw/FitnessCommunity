using FitnessCommunity.Domain.Abstractions;
using FitnessCommunity.Domain.Entities;
using FitnessCommunity.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FitnessCommunity.Infrastructure.Database.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly FitnessCommunityDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;
        public ExerciseRepository(FitnessCommunityDbContext dbContext, IUnitOfWork unitOfWork)
        {
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Exercise>> GetAllAsync()
        {
            return await _dbContext.Exercises.ToListAsync();
        }

        public async Task<Exercise> GetByIdAsync(Guid id)
        {
            return await _dbContext.Exercises.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task CreateAsync(Exercise exercise)
        {
            var entity = await _dbContext.Exercises.AddAsync(exercise);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var exercise = await _dbContext.Exercises.FirstOrDefaultAsync(e => e.Id == id);
            if (exercise != null)
            {
                _dbContext.Exercises.Remove(exercise);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Exercise exercise)
        {
            _dbContext.Exercises.Update(exercise);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
