using FitnessCommunity.Domain.Abstractions;

namespace FitnessCommunity.Infrastructure.Database.Abstractions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FitnessCommunityDbContext _context;

        public UnitOfWork(FitnessCommunityDbContext context)
        {
            _context = context;
        }



        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
