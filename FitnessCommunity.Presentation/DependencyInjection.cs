using Microsoft.Extensions.DependencyInjection;

namespace FitnessCommunity.Presentation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            return services;
        }
    }
}
