using FitnessCommunity.Domain.Entities;

namespace FitnessCommunity.Domain.Abstractions
{
    public interface ITokenService
    {
        string GenerateToken(User user);
        bool ValidateToken(string token);
        string RefreshToken(string refreshToken);
    }
}
