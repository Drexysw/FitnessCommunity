using FitnessCommunity.Domain.Entities;

namespace FitnessCommunity.Application.Abstractions
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
