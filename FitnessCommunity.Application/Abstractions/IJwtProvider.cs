using FitnessCommunity.Domain.Entities;

namespace FitnessCommunity.Application.Abstractions
{
    public interface IJwtProvider
    {
        string GenerateJwtToken(User user);
    }
}
