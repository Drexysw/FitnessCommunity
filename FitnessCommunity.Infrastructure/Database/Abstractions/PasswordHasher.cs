using FitnessCommunity.Domain.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace FitnessCommunity.Infrastructure.Database.Abstractions
{
    public class PasswordHasher(IPasswordHasher<object> passwordHasher) : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            return passwordHasher.HashPassword(null, password);
        }

        public bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            return passwordHasher.VerifyHashedPassword(null, hashedPassword, providedPassword) == PasswordVerificationResult.Success;
        }
    }
}
