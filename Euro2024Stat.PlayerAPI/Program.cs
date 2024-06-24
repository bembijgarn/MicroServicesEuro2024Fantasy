using Euro2024Stat.PlayerAPI.Extensions;
using EURO2024Stat.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureCors();


builder.Services.AddControllers();
builder.Services.ConfigureApiEndpointExplorer();
builder.Services.ConfigureSwaggerGen();
builder.AddAppAuthetication();


builder.Services.Configure<ConnectionString>(builder.Configuration.GetSection(nameof(ConnectionString)));
builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureMediatR();
builder.Services.AddAuthorization();


//Service Registration

builder.Services.RegisterPlayerService();

//
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
