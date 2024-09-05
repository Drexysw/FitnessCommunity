using FitnessCommunity.Domain.Entities;
using FitnessCommunity.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FitnessCommunity.Infrastructure.Database.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FitnessCommunityDbContext _dbContext;
        public UserRepository(FitnessCommunityDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User> GetUserByIdAsync(Guid userId)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }

        public Task<User> GetUserByUserNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByUserNameAndPasswordAsync(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUser(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
