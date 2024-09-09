using FitnessCommunity.Infrastructure.Database.Abstractions;
using Microsoft.Extensions.Options;

namespace FitnessCommunity.Server.OptionsSetup
{
    public class JwtOptionsSetup : IConfigureOptions<JwtOptions>
    {
        private const string SectionName = "JwtOptions";
        private readonly IConfiguration configuration;

        public JwtOptionsSetup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void Configure(JwtOptions options)
        {
             configuration.GetSection(SectionName).Bind(options);
        }
    }
}
