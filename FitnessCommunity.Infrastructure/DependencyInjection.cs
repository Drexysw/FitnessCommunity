using FitnessCommunity.Application.Abstractions;
using FitnessCommunity.Domain.Abstractions;
using FitnessCommunity.Domain.Repositories;
using FitnessCommunity.Infrastructure.Database;
using FitnessCommunity.Infrastructure.Database.Abstractions;
using FitnessCommunity.Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessCommunity.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IPasswordHasher,PasswordHasher>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IWorkoutRepository, WorkoutRepository>();
            services.AddScoped<IExerciseRepository, ExerciseRepository>();
            services.AddScoped<ITokenService, JwtTokenService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBadgeRepository, BadgeRepository>();

            services.AddDbContext<FitnessCommunityDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
