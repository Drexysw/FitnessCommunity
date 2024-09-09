using FitnessCommunity.Application.Abstractions;
using FitnessCommunity.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FitnessCommunity.Infrastructure.Database.Abstractions
{
    public sealed class JwtTokenService : ITokenService
    {
        private readonly JwtOptions config;

        public JwtTokenService(IOptions<JwtOptions> config)
        {
            this.config = config.Value;
        }
                                                                    
        public string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
            };

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.Key)),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                config.Issuer,
                config.Audience,
                claims,
                null,
                DateTime.UtcNow.AddHours(1),
                signingCredentials);

            string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenValue;
        }

        
    }
}
