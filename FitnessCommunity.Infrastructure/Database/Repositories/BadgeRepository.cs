using FitnessCommunity.Domain.Entities;
using FitnessCommunity.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FitnessCommunity.Infrastructure.Database.Repositories
{
    public class BadgeRepository(FitnessCommunityDbContext dbContext) : IBadgeRepository
    {
        public async Task<Badge?> GetByIdAsync(Guid id)
        {
            return await dbContext.Badges.FindAsync(id);
        }

        public async Task<IEnumerable<Badge>> GetAllAsync()
        {
            return await dbContext.Badges.Where(b => b != null).ToListAsync();
        }

        public async Task AddAsync(Badge badge)
        {
            await dbContext.Badges.AddAsync(badge);
        }

        public void UpdateAsync(Badge badge)
        {
            dbContext.Update(badge);
        }

        public void DeleteAsync(Badge badge)
        {
            dbContext.Badges.Remove(badge);
        }
    }
}