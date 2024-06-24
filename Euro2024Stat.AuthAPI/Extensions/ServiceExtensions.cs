
using Euro2024Stat.AuthAPI.Interface;
using Euro2024Stat.AuthAPI.Service;
using EURO2024Stat.DATA;
using EURO2024Stat.Domain;
using Microsoft.EntityFrameworkCore;

namespace Euro2024Stat.CountryAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        public static void ConfigureMediatR(this IServiceCollection service)
        {
            service.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(Program).Assembly));
        }

        public static void ConfigureCors(this IServiceCollection service)
        {
            service.AddCors();
        }
        public static void ConfigureApiEndpointExplorer(this IServiceCollection service)
        {
            service.AddEndpointsApiExplorer();
        }

        public static void ConfigureSwaggerGen(this IServiceCollection service)
        {
            service.AddSwaggerGen();
        }
        public static void RegisterJwtService(this IServiceCollection service)
        {
            service.AddScoped<IJwt, JwtService>();
        }
        public static void RegisterAuthService(this IServiceCollection service)
        {
            service.AddScoped<IAuth, AuthService>();
        }


    }
}
