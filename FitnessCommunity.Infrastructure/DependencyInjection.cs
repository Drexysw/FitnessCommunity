using System.Text;
using FitnessCommunity.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessCommunity.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<FitnessCommunityDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));


            return services;
        }
    }
}
