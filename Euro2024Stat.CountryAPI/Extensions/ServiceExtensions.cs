using Euro2024Stat.CountryAPI.Interface;
using Euro2024Stat.CountryAPI.Service;
using EURO2024Stat.DATA;
using EURO2024Stat.Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Euro2024Stat.CountryAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CountryContext>(options =>
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
            service.AddSwaggerGen(option =>
            {
                option.AddSecurityDefinition(name: JwtBearerDefaults.AuthenticationScheme, securityScheme: new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Enter the Bearer Authorization string as following: `Bearer Generated-JWT-Token`",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference= new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id= "Bearer"
                }
            }, new string[]{}
        }
    });
            });
        }

        public static void RegisterPublicCountryService(this IServiceCollection service)
        {
            service.AddScoped<IPublicCountry, PublicCountryService>();
        }
        public static void RegisterPrivateCountryService(this IServiceCollection service)
        {
            service.AddScoped<IPrivateCountry, PrivateCountryService>();
        }
        public static WebApplicationBuilder AddAppAuthetication(this WebApplicationBuilder builder)
        {
            var settingsSection = builder.Configuration.GetSection("ApiSettings");

            var secret = settingsSection.GetValue<string>("Secret");
            var issuer = settingsSection.GetValue<string>("Issuer");
            var audience = settingsSection.GetValue<string>("Audience");

            var key = Encoding.ASCII.GetBytes(secret);


            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    ValidateAudience = true
                };
            });

            return builder;
        }
    }
}
