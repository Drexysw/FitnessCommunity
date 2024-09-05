using FitnessCommunity.Domain.Entities;

namespace FitnessCommunity.Domain.Repositories
{
    public interface IBadgeRepository
    {
        Task<Badge?> GetByIdAsync(Guid id);
        Task<IEnumerable<Badge>> GetAllAsync();
        Task AddAsync(Badge badge);
        void UpdateAsync(Badge badge);
        void DeleteAsync(Badge badge);
    }
}
