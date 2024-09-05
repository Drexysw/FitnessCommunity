using FitnessCommunity.Domain.Entities;

namespace FitnessCommunity.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(Guid userId);
        Task<User> GetUserByUserNameAsync(string userName);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByUserNameAndPasswordAsync(string userName, string password);
        Task<User> GetUserByEmailAndPasswordAsync(string email, string password);
        Task<IEnumerable<User>> GetUsersAsync();
        Task AddUserAsync(User user);
        Task UpdateUser(User user);
        Task DeleteUser(Guid userId);
    }
}
