using FitnessCommunity.Application;
using FitnessCommunity.Infrastructure;
using FitnessCommunity.Presentation;
using FitnessCommunity.Server.OptionsSetup;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace FitnessCommunity.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services
                .AddApplication(builder.Configuration)
                .AddInfrastructure(builder.Configuration)
                .AddPresentation();


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer();

            builder.Services.ConfigureOptions<JwtOptionsSetup>();
            builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
