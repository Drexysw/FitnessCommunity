using FitnessCommunity.Application.Abstractions;
using FitnessCommunity.Domain.Abstractions;
using FitnessCommunity.Domain.Repositories;
using FitnessCommunity.Infrastructure.Authentication;
using FitnessCommunity.Infrastructure.Authentication.OptionsSetup;
using FitnessCommunity.Infrastructure.Cryptography;
using FitnessCommunity.Infrastructure.Database;
using FitnessCommunity.Infrastructure.Database.Abstractions;
using FitnessCommunity.Infrastructure.Database.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer();
            services.ConfigureOptions<JwtOptionsSetup>();
            services.ConfigureOptions<JwtBearerOptionsSetup>();

            services.AddAuthorization();

            services.AddSingleton<IPasswordHasher,PasswordHasher>();
            services.AddScoped<IJwtProvider, JwtProvider>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IWorkoutRepository, WorkoutRepository>();
            services.AddScoped<IExerciseRepository, ExerciseRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBadgeRepository, BadgeRepository>();
            return services;
        }
    }
}
