using Euro2024Stat.AuthAPI.Models;
using Euro2024Stat.CountryAPI.Extensions;
using EURO2024Stat.DATA;
using EURO2024Stat.Domain;
using Microsoft.AspNetCore.Identity;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.ConfigureCors();

builder.Services.AddControllers();
builder.Services.ConfigureApiEndpointExplorer();
builder.Services.ConfigureSwaggerGen();

builder.Services.Configure<Jwt>(builder.Configuration.GetSection("ApiSettings:JwtOptions"));
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<UserContext>()
    .AddDefaultTokenProviders();
builder.Services.Configure<ConnectionString>(builder.Configuration.GetSection(nameof(ConnectionString)));
builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureMediatR();
builder.Services.RegisterAuthService();
builder.Services.RegisterJwtService();
builder.Services.AddScoped<RoleManager<IdentityRole>>();
builder.Services.AddScoped<UserManager<User>>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
